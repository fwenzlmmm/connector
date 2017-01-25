using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using AWSHubService.Models;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AWSHubService.Attributes;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;
using Amazon.Runtime;
using Amazon.S3;
using Newtonsoft.Json;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AWSHubService.Controllers
{
    [Route("api/[controller]")]
    public class SecurityController : Controller
    {
        private readonly IOptions<AppSettings> _config;
        private readonly ILogger _logger;

        public IOptions<AppSettings> Config
        {
            get { return _config;  }
        }
        public ILogger Logger
        {
            get { return _logger; }
        }

        public SecurityController(IOptions<AppSettings> config, ILogger<SecurityController> logger)
        {
            this._config = config;
            _logger = logger;
        }

        //[RequireClientCert(Config, _logger)]
        [RequireClientCert]
        [HttpGet]
        public Credentials Get()
        {
            return GetAWSToken();
        }

        [HttpGet("Credentials", Name = "Credentials")]
        public Credentials GetCredentials()
        {
            return GetAWSToken();
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private Credentials GetAWSToken()
        {
            Amazon.SecurityToken.Model.Credentials credentials = null;

            Amazon.SecurityToken.AmazonSecurityTokenServiceConfig awsConfig = new AmazonSecurityTokenServiceConfig();
            if (System.IO.File.Exists(_config.Value.AWS.ProfilesLocation))
            { 
                string readText = System.IO.File.ReadAllText(_config.Value.AWS.ProfilesLocation);
                if(!string.IsNullOrWhiteSpace(readText))
                {
                    readText = readText.Substring(readText.IndexOf('\n') + 1); //skip the first line
                    string[] elements = readText.Split(new char[] { '\r', '\n' });
                    Dictionary<string, string> awsProfileEntries = new Dictionary<string, string>();
                    foreach (string element in elements)
                    {
                        if(!String.IsNullOrWhiteSpace(element) && element.IndexOf("=") > -1)
                        { 
                            string[] children = element.Split('=');
                            awsProfileEntries.Add(children[0].Trim(), children[1].Trim());
                        }
                    }
                AmazonSecurityTokenServiceClient stsClient = new AmazonSecurityTokenServiceClient(awsProfileEntries["aws_access_key_id"], awsProfileEntries["aws_secret_access_key"]);
                GetSessionTokenRequest getSessionTokenRequest = new GetSessionTokenRequest();
                // Following duration can be set only if temporary credentials are requested by an IAM user.
                getSessionTokenRequest.DurationSeconds = 7200; // seconds.
                Task<GetSessionTokenResponse> task = stsClient.GetSessionTokenAsync(getSessionTokenRequest);
                task.Wait();
                GetSessionTokenResponse tokenResponse = task.Result;
                credentials = tokenResponse.Credentials;

                    /*
                sessionCredentials = new SessionAWSCredentials(credentials.AccessKeyId,
                                                                credentials.SecretAccessKey,
                                                                credentials.SessionToken);
                    jsonCredentials = JsonConvert.SerializeObject(credentials);
                    AmazonS3Config s3Config = new AmazonS3Config();
                    s3Config.AuthenticationRegion = config.Value.AWSRegion;
                    s3Config.RegionEndpoint = Amazon.RegionEndpoint.USEast1;
                    //s3Config.ServiceURL = config.Value.AWSEndpointUrl;
                    AmazonS3Client s3Client = new AmazonS3Client(sessionCredentials, s3Config);
                    TransferUtility fileTransferUtility = new TransferUtility(s3Client);
                    fileTransferUtility.Upload(@"C:\HubFiles\Samples\Data.xlsx", config.Value.AWSS3BucketName);
                    */
                    // Test. For example, send request to list object key in a bucket.
                    //var response = s3Client.ListObjectsAsync(bucketName);
                    /*
                    string objectContent =
                                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc tortor metus, sagittis eget augue ut,\n"
                                + "feugiat vehicula risus. Integer tortor mauris, vehicula nec mollis et, consectetur eget tortor. In ut\n"
                                + "elit sagittis, ultrices est ut, iaculis turpis. In hac habitasse platea dictumst. Donec laoreet tellus\n"
                                + "at auctor tempus. Praesent nec diam sed urna sollicitudin vehicula eget id est. Vivamus sed laoreet\n"
                                + "lectus. Aliquam convallis condimentum risus, vitae porta justo venenatis vitae. Phasellus vitae nunc\n"
                                + "varius, volutpat quam nec, mollis urna. Donec tempus, nisi vitae gravida facilisis, sapien sem malesuada\n"
                                + "purus, id semper libero ipsum condimentum nulla. Suspendisse vel mi leo. Morbi pellentesque placerat congue.\n"
                                + "Nunc sollicitudin nunc diam, nec hendrerit dui commodo sed. Duis dapibus commodo elit, id commodo erat\n"
                                + "congue id. Aliquam erat volutpat.\n";
                    awsSigV4 = new AWSSigV4(this.config);

                    token = awsSigV4.GetAWSSecurityToken("s3", "POST", "MySampleFile.txt", objectContent);
                    */
                }
            }
            credentials.AccessKeyId = "YourTemporaryAccessKeyId";
            credentials.SecretAccessKey = "YourTemporarySecretAccessKey";
            credentials.SessionToken = "YourTemporarySessionToken";
            return credentials;
        }
    }
}
