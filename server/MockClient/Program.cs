using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {

        private static DiscoveryDocumentResponse GetDiscoveryDoc()
        {
            var client = new HttpClient();
            var mytask = client.GetDiscoveryDocumentAsync("https://localhost:5001");

            mytask.Wait();
            return mytask.Result;

        }

        private static async Task Main()
        {
            Console.WriteLine("Pooh");

            // discover endpoints from metadata
            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            //var disco = GetDiscoveryDoc();


            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            
            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "noUserClient",
                ClientSecret = "secret",

                Scope = "sessionapi"
            });


            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }


            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            // call api
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync("https://localhost:6001/identity");
            Console.WriteLine("PoohPants");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }


            Console.ReadLine();
        }
    }
}
