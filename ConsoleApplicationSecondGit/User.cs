using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationSecondGit
{
    // 5. Add Builder by Interfaces
    public interface IUsername
    {
        IPassword SetUsername(string username);
    }

    public interface IPassword
    {
        IOrgPin SetPassword(string password);
    }

    public interface IOrgPin
    {
        IDatabaseName SetOrgPin(string orgPin);
    }

    public interface IDatabaseName
    {
        IUserBuild SetDatabaseName(string databaseName);
    }

    public interface IUserBuild
    {
        IUserBuild SetEmail(string email);
        IUserBuild SetAddress(string address);
        // 5. Add Builder by Interfaces
        //User Build();
        // 6. Add Dependency Inversion
        IUser Build();
    }

    //public interface IUserBuilded : IUsername, IPassword, IOrgPin, IDatabaseName, IUserBuild, IUser { }

    public class User : IUsername, IPassword, IOrgPin, IDatabaseName, IUserBuild, IUser
    //public class User : IUserBuilded
    {
        public string Username { get; private set; }        // Required
        public string Password { get; private set; }        // Required
        public string OrgPin { get; private set; }          // Required
        public string DatabaseName { get; private set; }    // Required
        public string Email { get; private set; }
        public string Address { get; private set; }

        // 1. Classic Constructor.
        //public User(string username, string password, string orgPin, string databaseName)
        //{
        //    Username = username;
        //    Password = password;
        //    OrgPin = orgPin;
        //    DatabaseName = databaseName;
        //    Email = "";
        //    Address = "";
        //}

        // 1. Classic Constructor.
        //public User(string username, string password, string orgPin, string databaseName,
        //    string email, string address)
        //{
        //    Username = username;
        //    Password = password;
        //    OrgPin = orgPin;
        //    DatabaseName = databaseName;
        //    Email = email;
        //    Address = address;
        //}

        // 2. Default Constructor and Setters
        //public User()
        //{
        //    Username = "";
        //    Password = "";
        //    OrgPin = "";
        //    DatabaseName = "";
        //    Email = "";
        //    Address = "";
        //}

        // 4. Add Static Factory
        //private User()
        //{
        //    Username = "";
        //    Password = "";
        //    OrgPin = "";
        //    DatabaseName = "";
        //    Email = "";
        //    Address = "";
        //}

        // 5. Add Builder by Interfaces
        private User()
        {
            Email = "";
            Address = "";
        }

        // 4. Add Static Factory
        //public static User Get()
        // 5. Add Builder by Interfaces
        public static IUsername Get()
        {
            return new User();
        }

        // 2. Default Constructor and Setters
        //public void SetUsername(string username)
        // 3. Add Fluent Interface
        //public User SetUsername(string username)
        // 5. Add Builder by Interfaces
        public IPassword SetUsername(string username)
        {
            Username = username;
            return this;
        }

        public IOrgPin SetPassword(string password)
        {
            Password = password;
            return this;
        }

        public IDatabaseName SetOrgPin(string orgPin)
        {
            OrgPin = orgPin;
            return this;
        }

        public IUserBuild SetDatabaseName(string databaseName)
        {
            DatabaseName = databaseName;
            return this;
        }

        public IUserBuild SetEmail(string email)
        {
            Email = email;
            return this;
        }

        public IUserBuild SetAddress(string address)
        {
            Address = address;
            return this;
        }

        // 5. Add Builder by Interfaces
        //public User Build()
        // 6. Add Dependency Inversion
        public IUser Build()
        {
            return this;
        }

        // Override
        //public override string ToString()
        public string ToString()
        {
            return "Username: " + Username + " OrgPin: " + OrgPin + " DatabaseName: " + DatabaseName
                + " Email: " + Email + " Address: " + Address;
        }
    }
}
