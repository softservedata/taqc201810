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
        public static Logger log = LogManager.GetCurrentClassLogger(); // for NLog

        private UserRepository()
        {
        }

        public static User GetOBAdmin()
        {
            log.Debug("PREPARE GetOBAdmin");
            return new User(
                Environment.GetEnvironmentVariable("JAZZ_LOGIN"),
                Environment.GetEnvironmentVariable("JAZZ_PASSWORD"),
                Environment.GetEnvironmentVariable("JAZZ_PIN"),
                Environment.GetEnvironmentVariable("JAZZ_DATABASE")
                );
        }

    }
}
