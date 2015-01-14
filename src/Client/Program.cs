using System;
using System.Collections.Generic;

using System.Net.Http;
using System.Net.Http.Headers;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ENTER to call the API.");
            Console.ReadLine();

            var client = new Auth0.Client("aJ720Y4ZCU97EsAfNabs4lLW3GzfTGE0", "tenant.auth0.com");
            var token = client.LoginUser("client01-serviceidentity@mycompany.com", "abc", 
                "Username-Password-Authentication", "openid profile");

            var apiClient = new HttpClient();
            apiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.IdToken);

            var response = apiClient.GetAsync("http://localhost:25100/api/sample").Result;
            var content = response.Content.ReadAsAsync<IEnumerable<ClaimItem>>().Result;

            Console.WriteLine("Call complete. Data received:");

            foreach (var item in content)
                Console.WriteLine(" > {0}: {1}", item.Type, item.Value);
            Console.ReadLine();
        }
    }
}
