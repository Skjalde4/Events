using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Persistency;

namespace Events.Model
{
    class UserSingleton
    {
        private static UserSingleton _instance = new UserSingleton();

        public static UserSingleton Instance
        {
            get { return _instance ?? (_instance = new UserSingleton()); }
        }

        public ObservableCollection<User> Users { get; set; }

        private UserSingleton()
        {
            Users = new ObservableCollection<User>();
            LoadUserAsync();
        }

        public async void LoadUserAsync()
        {
            //var users = await PersistencyServiceUser.LoadEventsFromJsonAsync();

            //Test
            Users.Add(new User("HelenaG", "Helena", "Helena", "Graff", "28580211"));
        }

        public void Add(string userName, string passWord, string firstName, string lastName, string phonenumber)
        {
            Users.Add(new User(userName, passWord, firstName, lastName, phonenumber));
            PersistencyServiceUser.SaveEventsAsJsonAsync(Users);
        }

        public void Remove(User usersToBeRemoved)
        {
            Users.Remove(usersToBeRemoved);
            PersistencyServiceUser.SaveEventsAsJsonAsync(Users);
        }
    }
}
