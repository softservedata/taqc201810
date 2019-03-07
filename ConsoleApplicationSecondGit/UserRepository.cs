using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationSecondGit
{
    public sealed class UserRepository
    {
        private volatile static UserRepository instance = null;
        private static object lockingObject = new object();

        private UserRepository()
        {
        }

        public static UserRepository Get()
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new UserRepository();
                    }
                }
            }
            return instance;
        }

        public IUser Admin()
        {
            return User.Get()
                .SetUsername("Username7")
                .SetPassword("Password7")
                .SetOrgPin("OrgPin7")
                .SetDatabaseName("DatabaseName7")
                .SetEmail("Email7")
                .Build();
        }

    }
}
