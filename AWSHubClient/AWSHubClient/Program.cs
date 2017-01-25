using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.SecurityToken.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AWSHubClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Task task = SendRequest(ConfigurationManager.AppSettings["URL"]);
                task.Wait();
                task = SendRequestUsingClientCertificate(ConfigurationManager.AppSettings["URL"]);
                task.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Main Error: " + ex.Message);
            }
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        private static async Task SendRequest(string url)
        {
            try
            {
                WebRequestHandler handler = new WebRequestHandler();
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(url.Replace("https", "http"));
                    //client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    /*
                    X509Certificate certificate = GetCert();
                    handler.ClientCertificates.Add(certificate);
                    handler.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
                    handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                    */
                    HttpResponseMessage response = await client.GetAsync("api/Security/Credentials");
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Credentials credentials = JsonConvert.DeserializeObject<Credentials>(content);

                        SessionAWSCredentials sessionCredentials = new SessionAWSCredentials(credentials.AccessKeyId,
                                                                credentials.SecretAccessKey,
                                                                credentials.SessionToken);
                        // The following will be part of your less trusted code. You provide temporary security
                        // credentials so it can send authenticated requests to Amazon S3. 
                        // Create Amazon S3 client by passing in the basicSessionCredentials object.
                        try
                        { 
                            AmazonS3Config s3Config = new AmazonS3Config();
                            s3Config.AuthenticationRegion = ConfigurationManager.AppSettings["AWSRegion"];
                            //s3Config.ServiceURL = ConfigurationManager.AppSettings["AWSEndpointUrl"];
                            s3Config.RegionEndpoint = Amazon.RegionEndpoint.USEast1;
                            AmazonS3Client s3Client = new AmazonS3Client(sessionCredentials, s3Config);
                            TransferUtility fileTransferUtility = new TransferUtility(s3Client);
                            fileTransferUtility.Upload(@"C:\HubFiles\Samples\Data.xlsx", ConfigurationManager.AppSettings["AWSS3BucketName"]);
                        }
                        catch (AmazonS3Exception s3Exception)
                        {
                            Console.WriteLine(s3Exception.Message,
                                              s3Exception.InnerException);
                        }
                        /*
                        PutObjectRequest putRequest = new PutObjectRequest();
                        putRequest.BucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];
                        putRequest.ContentType
                        s3Client.PutObject()
                        */
                        Console.WriteLine("Received response: {0}", content);
                    }
                    else
                    {
                        Console.WriteLine("Error, received status code {0}: {1}", response.StatusCode, response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SendRequest Error: " + ex.Message);
            }
        }

        private static async Task SendRequestUsingClientCertificate(string url)
        {
            try
            {
                WebRequestHandler handler = new WebRequestHandler();
                X509Certificate certificate = GetCert();
                handler.ClientCertificates.Add(certificate);
                handler.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/Security");
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Credentials credentials = JsonConvert.DeserializeObject<Credentials>(content);

                        SessionAWSCredentials sessionCredentials = new SessionAWSCredentials(credentials.AccessKeyId,
                                                                credentials.SecretAccessKey,
                                                                credentials.SessionToken);
                        // The following will be part of your less trusted code. You provide temporary security
                        // credentials so it can send authenticated requests to Amazon S3. 
                        // Create Amazon S3 client by passing in the basicSessionCredentials object.
                        try
                        {
                            AmazonS3Config s3Config = new AmazonS3Config();
                            s3Config.AuthenticationRegion = ConfigurationManager.AppSettings["AWSRegion"];
                            //s3Config.ServiceURL = ConfigurationManager.AppSettings["AWSEndpointUrl"];
                            s3Config.RegionEndpoint = Amazon.RegionEndpoint.USEast1;
                            AmazonS3Client s3Client = new AmazonS3Client(sessionCredentials, s3Config);
                            TransferUtility fileTransferUtility = new TransferUtility(s3Client);
                            fileTransferUtility.Upload(@"C:\HubFiles\Samples\Data.xlsx", ConfigurationManager.AppSettings["AWSS3BucketName"]);
                        }
                        catch (AmazonS3Exception s3Exception)
                        {
                            Console.WriteLine(s3Exception.Message,
                                              s3Exception.InnerException);
                        }
                        /*
                        PutObjectRequest putRequest = new PutObjectRequest();
                        putRequest.BucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];
                        putRequest.ContentType
                        s3Client.PutObject()
                        */
                        Console.WriteLine("Received response: {0}", content);
                    }
                    else
                    {
                        Console.WriteLine("Error, received status code {0}: {1}", response.StatusCode, response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SendRequestUsingClientCertificate Error: " + ex.Message);
            }
        }

        public static bool ValidateServerCertificate(
          object sender,
          X509Certificate certificate,
          X509Chain chain,
          SslPolicyErrors sslPolicyErrors)
        {
            Console.WriteLine("Validating certificate {0}", certificate.Issuer);
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return true;
        }

        public static X509Certificate2 GetCert()
        {
            X509Store certStore = new X509Store("MY", StoreLocation.LocalMachine);
            certStore.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            X509Certificate2Collection collection = (X509Certificate2Collection)certStore.Certificates;
            X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindByThumbprint, Regex.Replace(ConfigurationManager.AppSettings["ClientCertThumbprint"], @"[^\da-zA-z]", string.Empty).ToUpper(), false);
            if (fcollection != null && fcollection.Count > 0)
                return fcollection[0];
            else
                return null;
        }
    }
}
