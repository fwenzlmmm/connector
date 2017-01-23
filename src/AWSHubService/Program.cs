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

namespace AWSHubService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                X509Certificate2 certificate = GetCert();
                //string[] baseUrls = new string[] { "http://www.3m.HubServices.Com:8080" };
                //string[] baseUrls = new string[] { "http://54.85.167.42:8080" };
                string[] baseUrls = new string[] { "http://10.104.92.89:8080" };
                var host = new WebHostBuilder()
                    .UseKestrel()
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

        public static X509Certificate2 GetCert()
        {
            X509Store certStore = new X509Store("Root", StoreLocation.LocalMachine);
            certStore.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            X509Certificate2Collection collection = (X509Certificate2Collection)certStore.Certificates;
            X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindByThumbprint, Regex.Replace("‎‎‎6b78f93c348fa1ca24f37cf78e177990772e1060", @"[^\da-zA-z]", string.Empty).ToUpper(), false);
            if (fcollection != null && fcollection.Count > 0)
                return fcollection[0];
            else
                return null;
        }
    }
}
