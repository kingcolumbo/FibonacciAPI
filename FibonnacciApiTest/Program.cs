using Newtonsoft.Json;
using RestSharp;
using System;

namespace FibonnacciApiTest
{
    /// <summary>
    /// client test harness for Fibonnaci API
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            /**Change input variable here**/
            int fibnum = 1000;

            Console.WriteLine("Sending client request for authentication.....");
            string reqBody = "{\"client_id\":\"K0guKMVsB66ShCXY534ai6s3VaUcX3Bk\",\"client_secret\":\"WitGv20faTT_lHXsKULM-Bq8qIcaF5NJi_ZT2Ef_ReVCxqpxzlo8Ce-3m-XWvrkI\",\"audience\":\"https://fib.com\",\"grant_type\":\"client_credentials\"}";
            var client = new RestClient("https://dev-y1efev-o.au.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", reqBody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            AuthModel model = JsonConvert.DeserializeObject<AuthModel>(response.Content); 
            Console.WriteLine(response.Content);
            Console.WriteLine("-------------------------");
            var apiClient = new RestClient("https://localhost:5001/api/fib/"+ fibnum.ToString());
            Console.WriteLine("Finding the nth Fibonnacci number where n="+fibnum.ToString());

            var apiRequest = new RestRequest(Method.GET);
            apiRequest.AddHeader("authorization", "Bearer " + model.access_token);
            IRestResponse apiResponse = apiClient.Execute(apiRequest);
            Console.WriteLine("Result is: " + apiResponse.Content.ToString());

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
