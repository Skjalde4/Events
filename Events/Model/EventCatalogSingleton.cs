using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.ApplicationModel.Activation;
using Events.Persistency;
using Events.ViewModel;

namespace Events.Model
{
    class EventCatalogSingleton
    {
        private static EventCatalogSingleton _instance = null;

        public static EventCatalogSingleton Instance
        {
            get { return _instance ?? (_instance = new EventCatalogSingleton()); }
        }

        public ObservableCollection<Event> Events { get; set; }

        private EventCatalogSingleton()
        {
            Events = new ObservableCollection<Event>();
           // LoadEventsAsync();
            GetEventAsync();
            
            
        }

        //public async void LoadEventsAsync()
        //{
        //    var events = await PersistencyServiceEvents.LoadEventsFromJsonAsync();
        //    if (events != null)
        //        foreach (var ev in events)
        //        {
        //            Events.Add(ev);
        //        }
        //    else
        //    {
        //        Events.Add(new Event(1, "Wedding", "Best day", "Paris", DateTime.Today));
        //    }

        //}

        public async void GetEventAsync()
        {
            var events = await PersistencyServiceEvents.GetEventAsync();
            if (events != null)
                foreach (var ev in events)
                {
                    Events.Add(ev);
                }
            
            
        }


        public async void Add(int id, string name, string description, string place, DateTime dateTime)
        {
            Event events = new Event(id, name, description, place, dateTime);
            Events.Add(events);
            PersistencyServiceEvents.PostEventAsync(events);

        }

        public async void PutEventAsync(int id, string name, string description, string place, DateTime dateTime)
        {
            Event events = new Event(id, name, description, place, dateTime);
            Events.Add(events);
            PersistencyServiceEvents.PutEventAsync(events);
        }


        //public  void Add(Event newEvent)
        //{
        //    Events.Add(newEvent);
        //    PersistencyServiceEvents.SaveEventsAsJsonAsync(Events);

        //}

        public void Remove(Event eventToBeRemoved)
        {
            Events.Remove(eventToBeRemoved);
            PersistencyServiceEvents.SaveEventsAsJsonAsync(Events);
        }

        


    }
}