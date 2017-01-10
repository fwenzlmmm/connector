using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using System.Security.Cryptography.X509Certificates;

namespace AWSHubService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pfxFile = Path.Combine(@"c:\certs", "HubClientCert.pfx");
            X509Certificate2 certificate = new X509Certificate2(pfxFile, "password");
            string[] baseUrls = new string[] { "http://www.3m.hubservices.com:80", "https://www.3m.hubservices.com:443" };
            var host = new WebHostBuilder()
                .UseKestrel(options =>
                {
                    HttpsConnectionFilterOptions httpsoptions = new HttpsConnectionFilterOptions();
                    httpsoptions.ServerCertificate = certificate;
                    httpsoptions.ClientCertificateMode = ClientCertificateMode.AllowCertificate;
                    httpsoptions.CheckCertificateRevocation = false;

                    options.UseHttps(httpsoptions);
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls(baseUrls)
                .Build();

            host.Run();
        }
    }
}
