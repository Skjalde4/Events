using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Events.Annotations;

namespace Events.Model
{
    class EventCategory : INotifyPropertyChanged
    {
        public string EC { get; set; }
        public Uri Uri { get; set; }

        public EventCategory(string ec, Uri uri)
        {
            EC = ec;
            Uri = uri;
        }


        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
