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
using User = Windows.System.User;

namespace Events.ViewModel
{
    class UserViewModel : INotifyPropertyChanged
    {
        private string _text;
        private ObservableCollection<User> _users;
        public UserSingleton UserSingleton { get; set; }

        

        public UserViewModel()
        {
            _users = new ObservableCollection<User>();
            UserSingleton = UserSingleton.Instance;
        }

        public string userName { get; set; }
        public string passWord { get; set; }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }
        public ObservableCollection<User> Users
        {
            get => _users;
            set => _users = value;
        }

        public void CheckUser()
        {
            foreach (Model.User user in UserSingleton.Users)
            {
                if (user.userName == userName && user.passWord == passWord)
                {
                    ((Frame) Window.Current.Content).Navigate(typeof(CreateEvent));
                }
            }

            Text = "User not found";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
