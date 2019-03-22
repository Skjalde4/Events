using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Events.Model;
using Newtonsoft.Json;

namespace Events.Persistency
{
    class PersistencyServiceEvents
    {
        private static string eventFileName = "Events.json";


        public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> events)
        {
            string eventsJsonString = JsonConvert.SerializeObject(events);
            SerializeEventsFileAsync(eventsJsonString, eventFileName);
        }

        public static async Task<List<Event>> LoadEventsFromJsonAsync()
        {
            string eventsJsonString = await DeSerializeEventsFileAsync(eventFileName);
            if (eventsJsonString != null)
                return (List<Event>)JsonConvert.DeserializeObject(eventsJsonString, typeof(List<Event>));
            return null;
        }


        public static async void SerializeEventsFileAsync(string eventsString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, eventsString);
        }

        public static async Task<string> DeSerializeEventsFileAsync(String fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException ex)
            {

                //MessageDialogHelper.Show("File of Events not found! - Loading for the first time?", "File not found!");
                return null;
            }
        }

        public static async Task<List<Event>> GetEventAsync()
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
                    
                    // Get henter noget
                    var response = client.GetAsync("api/events").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var events = await response.Content.ReadAsAsync<IEnumerable<Event>>();
                        return (List<Event>) events;
                    }

                    return null;

                }
                catch ( Exception e)
                {

                    return null;
                }
            }
        }

        public static async void PostEventAsync(Event events)
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
                   
                    var post = await client.PostAsJsonAsync("Api/Events", events);
                    
                }
                catch (Exception e)
                {
                    new MessageDialog(e.Message).ShowAsync();
                }

            }
        }

        //public static async void PutEventAsync(Event events)




        private class MessageDialogHelper
        {
            public static async void Show(string content, string title)
            {
                MessageDialog messageDialog = new MessageDialog(content, title);
                await messageDialog.ShowAsync();
            }
        }
    }
}
