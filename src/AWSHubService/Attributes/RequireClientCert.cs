using AWSHubService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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

        public override void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.IsHttps)
            {
                context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            }
            else
            {
                Task<X509Certificate2> task = context.HttpContext.Connection.GetClientCertificateAsync();
                task.Wait();
                X509Certificate2 certificate = task.Result;

                if (certificate == null)
                {
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                }
                else
                {
                    if (certificate != null)
                    {
                        X509Certificate2 serverCertificate = Program.GetCert();
                        if(certificate.Thumbprint == serverCertificate.Thumbprint)
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
