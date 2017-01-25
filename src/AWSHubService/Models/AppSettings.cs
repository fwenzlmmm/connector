using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSHubService.Models
{
    public class AppSettings
    {
        public AWS AWS { get; set; }
        public string ClientCertThumbprint { get; set; }
        public string AWSAccessKey { get; set; }
        public string AWSSecretKey { get; set; }
        public string AWSS3BucketName { get; set; }
        public string AWSRegion { get; set; }
        public string AWSEndpointUrl { get; set; }
        public string ComplianceDB { get; set; }
        
    }

    public class AWS
    {
        public string Profile { get; set; }
        public string ProfilesLocation { get; set; }
        public string Region { get; set; }
    }
}
