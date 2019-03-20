using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Events.Converter;
using Events.Model;
using Events.ViewModel;

namespace Events.Handler
{
    class EventHandler
    {
        public EventViewModel EventViewModel { get; set; }

        public EventHandler(EventViewModel eventViewModel)
        {
            EventViewModel = eventViewModel;
        }

        public void CreateEvent()
        {
            Event newEvent = new Event(EventViewModel.Id,
                                        EventViewModel.Name,
                                        EventViewModel.Description,
                                        EventViewModel.Place,
                                        DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(EventViewModel.Date, EventViewModel.Time));
            EventViewModel.EventCatalogSingleton.Add(newEvent);

        }

        public void SetSelectedEvent(Event ev)
        {
            EventViewModel.SelectedEvent = ev;
        }
        public async void DeleteEvent()
        {

            // Create the message dialog and set its content
            var messageDialog = new MessageDialog("Are you sure you want to Delete the Event: " + EventViewModel.SelectedEvent.Name + " ?");

            // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand("No", null));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();



        }
        private void CommandInvokedHandler(IUICommand command)
        {
            EventViewModel.EventCatalogSingleton.Remove(EventViewModel.SelectedEvent);
        }
    }
}
