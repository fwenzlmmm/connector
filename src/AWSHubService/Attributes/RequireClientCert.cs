using AWSHubService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AWSHubService.Attributes
{
    public class RequireClientCert : RequireHttpsAttribute
    {
        private readonly IOptions<AppSettings> config;
        private readonly ILogger _logger;
        public RequireClientCert(IOptions<AppSettings> config, ILogger<RequireClientCert> logger)
        {
            this.config = config;
            _logger = logger;
        }

        public RequireClientCert()
        {
        }

        public override void OnAuthorization(AuthorizationFilterContext context)
        {
            EventId eventId = new EventId(1, "Info");                
            //_logger.LogInformation(eventId, "RequireClientCert:OnAuthorization", null);
            Console.WriteLine("RequireClientCert:OnAuthorization");
            if (!context.HttpContext.Request.IsHttps)
            {
                //_logger.LogInformation(eventId, "RequireClientCert:OnAuthorization:Forbidden", null);
                Console.WriteLine("RequireClientCert:OnAuthorization:Forbidden");
                context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            }
            else
            {
                //_logger.LogInformation(eventId, "RequireClientCert:OnAuthorization:GetClientCertificateAsync", null);
                Console.WriteLine("RequireClientCert:OnAuthorization:GetClientCertificateAsync");
                Task<X509Certificate2> task = context.HttpContext.Connection.GetClientCertificateAsync();
                task.Wait();
                X509Certificate2 certificate = task.Result;

                if (certificate == null)
                {
                    //_logger.LogInformation(eventId, "RequireClientCert:OnAuthorization: certificate == null", null);
                    Console.WriteLine("RequireClientCert:OnAuthorization: certificate == null");
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                }
                else
                {
                    if (certificate != null)
                    {
                        X509Certificate2 serverCertificate = Program.GetCert();
                        //_logger.LogInformation(eventId, "RequireClientCert:OnAuthorization: certificate != null", null);
                        Console.WriteLine("RequireClientCert:OnAuthorization: certificate Thumbprint: " + certificate.Thumbprint);

                        if (certificate.Thumbprint == serverCertificate.Thumbprint)
                            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    }
                }
            }
        }
    }

    public class ConfigurationAttribute : Attribute
    {
        public IOptions<AppSettings> Configuration { get; set; }
    }

}
