using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PostToMySqlRestAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string data = "";
                string result = "";
                int id = 0;
                Task<string> task = null;

                //display the initial records in the MySql ExtractDefinitions table
                Task<int> getTask = DisplayRecords(0);
                getTask.Wait();

                Console.WriteLine("insert a new record with the POST method");
                data = "{\"applicationId\":124,\"enterpriseId\":53002,\"name\":\"Test 5 Name\",\"queryDefinition\":\"Some other definition\",\"dateCreated\":\"2017-04-13T15:02:24\",\"dateUpdated\":\"2017-04-13T15:02:24\",\"createdBy\":1,\"updatedBy\":2}";
                task = SendRequestUsingCredentials(ConfigurationManager.AppSettings["URL"], id, data, Methods.POST);
                task.Wait();

                getTask = DisplayRecords(0);
                getTask.Wait();
                id = getTask.Result;

                Console.WriteLine(string.Format("display the latest record with the GET with ID method: ", id));
                getTask = DisplayRecords(id); //get the last record specifically by Id and display it
                getTask.Wait();


                //modify the last record
                Console.WriteLine(string.Format("modify the last record with the PUT method"));
                data = "{\"applicationId\":125,\"enterpriseId\":53005,\"name\":\"Test 10 Name\",\"queryDefinition\":\"Some other definition\",\"dateCreated\":\"2017-04-13T15:02:24\",\"dateUpdated\":\"2017-04-13T15:02:24\",\"createdBy\":1,\"updatedBy\":2}";
                task = SendRequestUsingCredentials(ConfigurationManager.AppSettings["URL"], id, data, Methods.PUT);
                task.Wait();

                getTask = DisplayRecords(0);
                getTask.Wait();

                //Delete the last record
                Console.WriteLine("delete the last record with the DEL method");
                task = SendRequestUsingCredentials(ConfigurationManager.AppSettings["URL"], id, data, Methods.DEL);
                task.Wait();

                getTask = DisplayRecords(0);
                getTask.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Main Error: " + ex.Message);
            }
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        private static async Task<int> DisplayRecords(int id)
        {
            int lastRecordId = 0;
            string data = "";
            string result = "";
            result = await SendRequestUsingCredentials(ConfigurationManager.AppSettings["URL"], id, data, Methods.GET);
            
            dynamic getResults = JsonConvert.DeserializeObject<dynamic>(result);
            if (getResults != null && getResults is IList && getResults.GetType() == typeof(JArray) && DoesPropertyExist(getResults, "Count"))
            {
                Console.WriteLine(string.Format("GET Call without parameters resulted in {0} records returned.", getResults.Count));
                foreach (object getResult in getResults)
                {
                    dynamic dynResult = JsonConvert.DeserializeObject<dynamic>(getResult.ToString());
                    if (dynResult != null)
                    {
                        Console.WriteLine(string.Format("Item Id: {0}, ApplicationId: {1}, EnterpriseId: {2}, Name: {3}", dynResult.id, dynResult.applicationId, dynResult.enterpriseId, dynResult.name));
                        lastRecordId = dynResult.id;
                    }
                }
            }
            else if (getResults != null && getResults.GetType() == typeof(JObject))
            {
                dynamic dynResult = JsonConvert.DeserializeObject<dynamic>(((JObject)getResults).ToString());
                Console.WriteLine(string.Format("Item Id: {0}, ApplicationId: {1}, EnterpriseId: {2}, Name: {3}", dynResult.id, dynResult.applicationId, dynResult.enterpriseId, dynResult.name));
                lastRecordId = dynResult.id;
            }
            else
            {
                Console.WriteLine(string.Format("GET Call with Id: {0} resulted in a NULL or Empty response.", id));
            }
            Console.WriteLine("");
            return lastRecordId;
        }

        public static bool DoesPropertyExist(dynamic settings, string name)
        {
            if (settings is ExpandoObject)
                return ((IDictionary<string, object>)settings).ContainsKey(name);

            return settings.GetType().GetProperty(name) != null;
        }

        private static async Task<string> SendRequestUsingCredentials(string url, int id, string data, Methods method)
        {
            string result = null;
            try
            {
                WebRequestHandler handler = new WebRequestHandler();
                if(url.ToLower().Contains("https:"))
                { 
                    X509Certificate certificate = GetCert(true);
                    handler.ClientCertificates.Add(certificate);
                    handler.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
                    handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                }
                using (var client = new HttpClient(handler))
                {
                    StringContent stringContent = null;
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var byteArray = Encoding.ASCII.GetBytes("jblow:3mHIs");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    HttpResponseMessage response = null;
                    switch (method)
                    {
                        case Methods.GET:
                            if(id > 0)
                                response = await client.GetAsync("api/definitions/" + id);
                            else
                                response = await client.GetAsync("api/definitions");
                            break;
                        case Methods.POST:
                            stringContent = new StringContent(data, Encoding.UTF8, "application/json");
                            response = await client.PostAsync("api/definitions/", stringContent);
                            break;
                        case Methods.PUT:
                            stringContent = new StringContent(data, Encoding.UTF8, "application/json");
                            response = await client.PutAsync("api/definitions/" + id, stringContent);
                            break;
                        case Methods.DEL:
                            response = await client.DeleteAsync("api/definitions/" + id);
                            break;
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                        //Console.WriteLine("Received response: {0}", result);
                    }
                    else
                    {
                        Console.WriteLine("Error, received status code {0}: {1}", response.StatusCode, response.ReasonPhrase);
                        Console.WriteLine("");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SendRequestUsingClientCertificate Error: " + ex.Message);
                Console.WriteLine("");
            }
            return result;
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

        public static X509Certificate2 GetCert(bool client)
        {
            X509Store certStore = new X509Store("MY", StoreLocation.LocalMachine);
            certStore.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            X509Certificate2Collection collection = (X509Certificate2Collection)certStore.Certificates;
            X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindByThumbprint, Regex.Replace((client ? ConfigurationManager.AppSettings["ClientCertThumbprint"] : ConfigurationManager.AppSettings["ServerCertThumbprint"]), @"[^\da-zA-z]", string.Empty).ToUpper(), false);
            if (fcollection != null && fcollection.Count > 0)
                return fcollection[0];
            else
                return null;
        }

    }

    public enum Methods
    {
        GET,
        POST,
        PUT,
        DEL
    }
}
