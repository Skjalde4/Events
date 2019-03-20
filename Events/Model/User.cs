using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Model
{
    class User
    {
        //Things being checked during login
        public string userName { get; set; }
        public string passWord { get; set; }

        //Things used to create account
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phonenumber { get; set; }

        public User(string userName, string passWord, string firstName, string lastName, string phonenumber)
        {
            this.userName = userName;
            this.passWord = passWord;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phonenumber = phonenumber;
        }

        public override string ToString()
        {
            return $"{nameof(userName)}: {userName}, {nameof(passWord)}: {passWord}, {nameof(firstName)}: {firstName}, {nameof(lastName)}: {lastName}, {nameof(phonenumber)}: {phonenumber}";
        }

    }
}
