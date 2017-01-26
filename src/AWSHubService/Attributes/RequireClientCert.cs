using AWSHubService.Controllers;
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
        public IOptions<AppSettings> Config { get; set; }
        public ILogger Logger { get; set; }

        public override void OnAuthorization(AuthorizationFilterContext context)
        {
            EventId eventId = new EventId(1, "Info");                
            Logger.LogInformation(eventId, "RequireClientCert:OnAuthorization", null);
            //Console.WriteLine("RequireClientCert:OnAuthorization");
            if (!context.HttpContext.Request.IsHttps)
            {
                Logger.LogInformation(eventId, "RequireClientCert:OnAuthorization:Forbidden", null);
                //Console.WriteLine("RequireClientCert:OnAuthorization:Forbidden");
                context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            }
            else
            {
                Logger.LogInformation(eventId, "RequireClientCert:OnAuthorization:GetClientCertificateAsync", null);
                //Console.WriteLine("RequireClientCert:OnAuthorization:GetClientCertificateAsync");
                Task<X509Certificate2> task = context.HttpContext.Connection.GetClientCertificateAsync();
                task.Wait();
                X509Certificate2 certificate = task.Result;

                if (certificate == null)
                {
                    Logger.LogInformation(eventId, "RequireClientCert:OnAuthorization: certificate == null", null);
                    //Console.WriteLine("RequireClientCert:OnAuthorization: certificate == null");
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                }
                else
                {
                    if (certificate != null)
                    {
                        X509Certificate2 serverCertificate = Program.GetCert(true);
                        if (serverCertificate != null)
                        {
                            Logger.LogInformation(eventId, "RequireClientCert:OnAuthorization: serverCertificate != null", null);
                            Logger.LogDebug(eventId, "RequireClientCert:OnAuthorization: serverCertificate Thumbprint: {serverCertificate.Thumbprint}", serverCertificate.Thumbprint);
                            Logger.LogDebug(eventId, "RequireClientCert:OnAuthorization: CLIENT Certificate Thumbprint: {certificate.Thumbprint}", certificate.Thumbprint);
                            //Console.WriteLine("RequireClientCert:OnAuthorization: certificate Thumbprint: " + certificate.Thumbprint);

                            if (certificate != null && serverCertificate != null && certificate.Thumbprint == serverCertificate.Thumbprint)
                            {
                                Logger.LogDebug(eventId, "RequireClientCert:OnAuthorization: CLIENT Certificate Authentication PASSED!");
                                context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                            }
                            else
                            {
                                Logger.LogDebug(eventId, "RequireClientCert:OnAuthorization: CLIENT Certificate Authentication FAILED!");
                                context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                            }
                        }
                        else
                        {
                            Logger.LogDebug(eventId, "RequireClientCert:OnAuthorization: CLIENT Certificate Authentication FAILED!");
                            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                        }
                    }
                }
            }
        }
    }
}
