using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EventWS;

namespace EventTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ServerUrl = "HTTP://localhost:55860";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    //Post tilføjer noget
                    //Event event1 = new Event() { Name = "Spa day", Place = "Comwell", Description = "Time to enjoy life", DateTime = DateTime.Now };
                    //var post = client.PostAsJsonAsync("Api/Events", event1).Result;
                    //Console.WriteLine(post.StatusCode);

                    //Put ændre noget
                    //Event event2 = new Event() { Name = "Spa day", Id = 1002, Description = "My birthday party", Place = "Maglegårdsvej 1, 4000 Roskilde", DateTime = DateTime.Now };
                    //var put = client.PutAsJsonAsync("api/events/1002", event2).Result;

                    ////Delete Sletter noget

                    var delete = client.DeleteAsync("api/events/1003").Result;

                    // Get henter noget
                    var response = client.GetAsync("api/events").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var events = response.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                        foreach (var e in events)
                        {
                            Console.WriteLine(e);
                        }
                    }


                   
                    
                }
                catch ( Exception e)
                {
                    Console.WriteLine(e);
                   
                }
            }
        }
    }
}
