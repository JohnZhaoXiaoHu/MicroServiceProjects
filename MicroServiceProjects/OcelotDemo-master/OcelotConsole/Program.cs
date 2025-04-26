using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace OcelotConsole
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                for (var i = 0; i < 100; i++)
                {
                    Console.WriteLine($"{DateTime.Now} ====> {i}");

                    var result = await client.GetAsync("http://localhost:5050/ocelot/aggrWilling");
                    Console.WriteLine($"{result.StatusCode}, {result.Content.ReadAsStringAsync().Result}");
                    System.Threading.Thread.Sleep(1000);
                }
                Console.Read();
            }
        }
    }
}
