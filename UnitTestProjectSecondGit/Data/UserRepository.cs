using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondGit.Data
{
    public sealed class UserRepository
    {
        private volatile static UserRepository instance = null;
        private static object lockingObject = new object();
        //
        public static Logger log = LogManager.GetCurrentClassLogger(); // for NLog

        private UserRepository()
        {
        }

        //public static User GetOBAdmin()
        //{
        //    log.Debug("PREPARE GetOBAdmin");
        //    return new User(
        //        Environment.GetEnvironmentVariable("JAZZ_LOGIN"),
        //        Environment.GetEnvironmentVariable("JAZZ_PASSWORD"),
        //        Environment.GetEnvironmentVariable("JAZZ_PIN"),
        //        Environment.GetEnvironmentVariable("JAZZ_DATABASE")
        //        );
        //}

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

        public IUser OBAdmin()
        {
            return User.Get()
                .SetUsername(Environment.GetEnvironmentVariable("JAZZ_LOGIN"))
                .SetPassword(Environment.GetEnvironmentVariable("JAZZ_PASSWORD"))
                .SetOrgPin(Environment.GetEnvironmentVariable("JAZZ_PIN"))
                .SetDatabaseName(Environment.GetEnvironmentVariable("JAZZ_DATABASE"))
                .SetEmail("email8@my.com")
                .Build();
        }

        //public IList<IUser> FromCsv()
        //{
        //    return FromCsv("users.csv");
        //}

        //public IList<IUser> FromCsv(string filename)
        //{
        //    return User.GetAllUsers(new CSVReader(filename).GetAllCells());
        //}

        //public IList<IUser> FromExcel()
        //{
        //    return FromExcel("users.xlsx");
        //}

        //public IList<IUser> FromExcel(string filename)
        //{
        //    return User.GetAllUsers(new ExcelReader(filename).GetAllCells());
        //}

    }
}
