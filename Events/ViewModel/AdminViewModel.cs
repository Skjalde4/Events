using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Events.Annotations;
using Events.Model;
using Events.View;

namespace Events.ViewModel
{
    class AdminViewModel : INotifyPropertyChanged
    {
        private string _text;
        private ObservableCollection<Admin> _admins;

        public AdminViewModel()
        {
            _admins = new ObservableCollection<Admin>();
            Adminlist();
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        public ObservableCollection<Admin> Admins
        {
            get => _admins;
            set => _admins = value;
        }

        public void Adminlist()
        {
                Admin Admin1 = new Admin("Admin", "Admin");
                _admins.Add(Admin1);
        }

        public void Check()
        {
            foreach (Admin admin in _admins)
            {
                if (admin.Username == Username && admin.Password == Password)
                {
                    ((Frame) Window.Current.Content).Navigate(typeof(AdminEdit));
                }
            }

            Text = "Admin not found";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
