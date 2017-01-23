using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AWSHubService.Models
{
    public class CertUtil
    {
        private readonly IOptions<AppSettings> config;
        public CertUtil(IOptions<AppSettings> config)
        {
            this.config = config;
        }
        public X509Certificate2 GetServerCert()
        {
            X509Store certStore = new X509Store("MY", StoreLocation.LocalMachine);
            certStore.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            X509Certificate2Collection collection = (X509Certificate2Collection)certStore.Certificates;
            X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindByThumbprint, Regex.Replace(config.Value.ClientCertThumbprint, @"[^\da-zA-z]", string.Empty).ToUpper(), false);
            if (fcollection != null && fcollection.Count > 0)
                return fcollection[0];
            else
                return null;
        }
    }
}
