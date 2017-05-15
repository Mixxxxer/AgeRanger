using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AgeRanger.Api.Client.Helper;
using Newtonsoft.Json;

namespace AgeRanger.Api.Client
{
    class Program
    {
        private static void Main()
        {
            try
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:9903/")
                };

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (ConfigHelper.RequiresApiKey)
                {
                    httpClient.DefaultRequestHeaders.Add("API_KEY", ConfigHelper.ApiKey);
                }
                
                httpClient.DefaultRequestHeaders.Add("Authorization", ConfigHelper.BasicAuth);

                ApiGet(httpClient).Wait();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            Console.ReadKey();
        }

        private static async Task ApiGet(HttpClient httpClient)
        {
            dynamic updatable = new { Id = 1, FirstName = "Bob", LastName = "Jones", Age = 45 };

            using (httpClient)
            {
                var payload = JsonConvert.SerializeObject(updatable);
                var content = new StringContent(payload, Encoding.UTF8, "application/json");

                var result = await httpClient.PutAsync(string.Format("api/person/{0}", updatable.Id), content);

                result.EnsureSuccessStatusCode();

                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Record with ID:{0} was updated", updatable.Id);
                }
            }
        }
    }
}
