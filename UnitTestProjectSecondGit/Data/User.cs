using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondGit.Data
{
    public class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string OrgPin { get; private set; }
        public string DatabaseName { get; private set; }

        public User(string username, string password, string orgPin, string databaseName)
        {
            Username = username;
            Password = password;
            OrgPin = orgPin;
            DatabaseName = databaseName;
        }

        public override string ToString()
        {
            return "Username: " + Username + " OrgPin: " + OrgPin + " DatabaseName: " + DatabaseName;
        }
    }
}
