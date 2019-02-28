//using log4net;
//using log4net.Config;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationSecondGit
{
    public class Program
    {
        //public static ILog log = LogManager.GetLogger(typeof(Program)); // for Log4net
        public static Logger log = LogManager.GetCurrentClassLogger(); // for NLog
        //public static Logger log = LogManager.GetLogger("rolling0"); // for NLog

        public static void Main(string[] args)
        {
            string jazzUrl = Environment.GetEnvironmentVariable("JAZZ_URL");
            string jazzLogin = Environment.GetEnvironmentVariable("JAZZ_LOGIN");
            string jazzPassword = Environment.GetEnvironmentVariable("JAZZ_PASSWORD");
            string jazzPin = Environment.GetEnvironmentVariable("JAZZ_PIN");
            string jazzDatabase = Environment.GetEnvironmentVariable("JAZZ_DATABASE");
            //
            Console.WriteLine("jazzUrl = " + jazzUrl);
            Console.WriteLine("jazzLogin = " + jazzLogin);
            Console.WriteLine("jazzPassword = " + jazzPassword);
            Console.WriteLine("jazzPin = " + jazzPin);
            Console.WriteLine("jazzDatabase = " + jazzDatabase);
            //
            Console.WriteLine("\n\n");
            //
            //BasicConfigurator.Configure();
            //XmlConfigurator.Configure();
            //
            log.Trace("NLOG: Trace Level test");
            log.Debug("2*Debug Level test");
            log.Info("2*Info Level");
            log.Warn("2*Warn Level");
            log.Warn("test");
            log.Error("2*Error Level test");
            log.Fatal("2*Fatal Level");
            //
            Console.WriteLine("Application Done");
        }
    }
}
