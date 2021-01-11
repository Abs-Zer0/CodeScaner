using System;
using System.Collections.Generic;
using System.Text;

namespace CodeScaner.Model.Settings
{
    public class Person
    {
        public Person(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

        public Person() : this("", "") { }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
