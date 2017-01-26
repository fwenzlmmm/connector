using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace AWSHubService
{
    public class Program
    {
        static public IConfigurationRoot Configuration { get; set; }
        public static void Main(string[] args)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

                Configuration = builder.Build();
                X509Certificate2 certificate = GetCert(false);
                //string[] baseUrls = new string[] { "http://www.3m.HubServices.Com:8080" };
                //string[] baseUrls = new string[] { "http://54.85.167.42:8080" };
                string[] baseUrls = new string[] { "http://10.104.92.89:80", "https://10.104.92.89:443" };
                var host = new WebHostBuilder()
                    
                    .UseKestrel(options =>
                    {
                        HttpsConnectionFilterOptions httpsoptions = new HttpsConnectionFilterOptions();
                        httpsoptions.ServerCertificate = certificate;
                        httpsoptions.ClientCertificateMode = ClientCertificateMode.AllowCertificate;
                        httpsoptions.CheckCertificateRevocation = false;
                        options.UseHttps(httpsoptions);
                    })

                    
                    //.UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseUrls(baseUrls)
                    .Build();

                host.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Initializatiuon Error: " + ex.Message + " Stacktrace: " + ex.StackTrace);
                Console.ReadLine();
            }
        }

        public static X509Certificate2 GetCert(bool client)
        {
            Console.WriteLine("Program Main GetCert: Start");
            if(!client) //get the server cert
            { 
                var cert = new X509Certificate2(Configuration["SSLCertificate:CertificateName"], Configuration["SSLCertificate:CertificatePwd"]);
                if (cert != null)
                {
                    Console.WriteLine("Loaded the CERT from the PFX file!");
                    return cert;
                }
                else
                { 
                    return null;
                }
            }
            else //get the client cert by thumbprint
            {
                var cert = new X509Certificate2(Configuration["SSLCertificate:ClientCertficateName"]);
                if (cert != null)
                {
                    Console.WriteLine("Found CLIENT Certificate!");
                    return cert;
                }
                else
                {
                    return null;
                }

                /*
                X509Store certStore = new X509Store("Root", StoreLocation.LocalMachine);
                certStore.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

                X509Certificate2Collection collection = (X509Certificate2Collection)certStore.Certificates;
                X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindByThumbprint, Regex.Replace(Configuration["AppSettings:ClientCertThumbprint"], @"[^\da-zA-z]", string.Empty).ToUpper(), false);
                if (fcollection != null && fcollection.Count > 0)
                {
                    Console.WriteLine("Program Main GetCert: Found CLIENT Certificate!");
                    Console.WriteLine("Program Main GetCert: Number of matching Certificates : " + fcollection.Count);
                    return fcollection[0];
                }
                else
                {
                    Console.WriteLine("Program Main GetCert: CLIENT Certificate NOT FOUND!");
                    return null;
                }
                */
            }
        }
    }
}
