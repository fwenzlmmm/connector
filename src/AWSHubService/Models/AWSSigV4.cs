using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSHubService.Models
{
    public class AWSSigV4
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        private readonly IOptions<AppSettings> config;
        private string awsAccessKey;
        private string awsSecretKey;

        public AWSSigV4(IOptions<AppSettings> config)
        {
            this.config = config;
            this.awsAccessKey = config.Value.AWSAccessKey;
            this.awsSecretKey = config.Value.AWSSecretKey;
        }

        public string GetAWSSecurityToken(string service, string method, string fileName, string fileContent)
        {
            string token = null;

            // Virtual hosted style addressing places the bucket name into the host address
            var endpointUri = new Uri(config.Value.AWSEndpointUrl + fileName);

            var contentHash = AWS4SignerBase.CanonicalRequestHashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(fileContent));
            var contentHashString = AWS4SignerBase.ToHexString(contentHash, true);

            var signer = new AWS4SignerForPOST
            {
                EndpointUri = endpointUri,
                HttpMethod = method,
                Service = service,
                Region = config.Value.AWSRegion
            };

            var keyName = fileName;

            var dateTimeStamp = DateTime.UtcNow;

            // construct the policy document governing the POST; note we need to request data from
            // the signer to complete the document ahead of the actual signing. The policy does not
            // need newlines but the sample uses them to make the resulting document clearer to read.
            // The double {{ and }} are needed to escape the {} sequences in the document.
            var policyBuilder = new StringBuilder();

            policyBuilder.AppendFormat("{{ \"expiration\": \"{0}\"\n", dateTimeStamp.AddDays(1).ToString("2013-08-07T12:00:00.000Z"));
            policyBuilder.Append("\"conditions\" : [");
            policyBuilder.AppendFormat("{{ \"bucket\": \"{0}\"\n", config.Value.AWSS3BucketName);
            policyBuilder.AppendFormat("[ \"starts-with\", \"$key\", \"{0}\"]\n", keyName);
            policyBuilder.Append("{{ \"acl\" : \"public-read\" }\n");
            policyBuilder.AppendFormat("{{ \"success_action_redirect\" : \"https://{0}.s3.amazonaws.com/successful_upload.html\" }}\n", config.Value.AWSS3BucketName);
            policyBuilder.Append("[ \"starts-with\", \"$Content-Type\", \"text/\"]\n");
            policyBuilder.AppendFormat("{{ \"{0}\" : \"14365123651274\" }}\n", AWS4SignerBase.X_Amz_Meta_UUID);
            policyBuilder.Append("[\"starts-with\", \"$x-amz-meta-tag\", \"\"]\n");

            // populate these with assistance from the signer
            policyBuilder.AppendFormat("{{ \"{0}\" : \"{1}\"}}\n", AWS4SignerBase.X_Amz_Credential, signer.FormatCredentialStringForPolicy(dateTimeStamp));
            policyBuilder.AppendFormat("{{ \"{0}\" : \"{1}\"}}\n", AWS4SignerBase.X_Amz_Algorithm, signer.FormatAlgorithmForPolicy);
            policyBuilder.AppendFormat("{{ \"{0}\" : \"{1}\" }}\n", AWS4SignerBase.X_Amz_Date, signer.FormatDateTimeForPolicy(dateTimeStamp));

            policyBuilder.Append("]\n}");

            // hash the Base64 version of the policy document and pass this to the signer as the body hash
            var policyStringBytes = Encoding.UTF8.GetBytes(policyBuilder.ToString());
            var base64PolicyString = System.Convert.ToBase64String(policyStringBytes);

            var headers = new Dictionary<string, string>
            {
                {AWS4SignerBase.X_Amz_Content_SHA256, contentHashString},
                {"content-length", fileContent.Length.ToString()},
                {"content-type", "text/plain"}
            };

            token  = signer.ComputeSignature(headers, 
                                                        "",   // no query parameters
                                                        base64PolicyString,
                                                        awsAccessKey,
                                                        awsSecretKey);
            return token;
        }
    }
}

