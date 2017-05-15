using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AgeRanger.Api.Client
{
    class Program
    {
        private static Dictionary<string, string> requestDictionary;

        private static void Main()
        {
            CreateRequestDictionary();

            var cons = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9903/")
            };

            cons.DefaultRequestHeaders.Accept.Clear();
            cons.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            foreach (var request in requestDictionary)
            {
                cons.DefaultRequestHeaders.Add(request.Key, request.Value);
            }

            try
            {
                ApiGet(cons).Wait();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            Console.ReadKey();
        }

        private static void CreateRequestDictionary()
        {
            requestDictionary = new Dictionary<string, string>
            {
                ["API_KEY"] = "A61D4BE4-F84C-4A24-9676-26B35DC479F7",
                ["Authorization"] = "Basic dXNlcm5hbWU6cGFzc3dvcmQ ="
            };
        }

        private static async Task ApiGet(HttpClient cons)
        {
            dynamic updatable = new
            {
                Id = 1,
                FirstName = "Paul",
                LastName = "Nilsen",
                Age = 45
            };

            using (cons)
            {
                var stringPayload = JsonConvert.SerializeObject(updatable);
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                var res = await cons.PutAsync(string.Format("api/person/{0}", updatable.Id), httpContent);

                res.EnsureSuccessStatusCode();

                if (res.IsSuccessStatusCode)
                {
                    Console.WriteLine("Record with ID:{0} was updated", updatable.Id);
                }
            }
        }
    }
}
