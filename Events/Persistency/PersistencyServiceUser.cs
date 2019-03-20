using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Events.Model;
using Newtonsoft.Json;

namespace Events.Persistency
{
    class PersistencyServiceUser
    {
        private static string eventFileName = "User.json";


        public static async void SaveEventsAsJsonAsync(ObservableCollection<User> users)
        {
            string eventsJsonString = JsonConvert.SerializeObject(users);
            SerializeEventsFileAsync(eventsJsonString, eventFileName);
        }

        public static async Task<List<User>> LoadEventsFromJsonAsync()
        {
            string eventsJsonString = await DeSerializeEventsFileAsync(eventFileName);
            if (eventsJsonString != null)
                return (List<User>)JsonConvert.DeserializeObject(eventsJsonString, typeof(List<User>));
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
