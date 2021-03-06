﻿using log4net;
using log4net.Config;
//using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationSecondGit
{
    public class Program
    {
        //public static ILog log = LogManager.GetLogger(typeof(Program)); // for Log4net
        //public static Logger log = LogManager.GetCurrentClassLogger(); // for NLog
        //public static Logger log = LogManager.GetLogger("rolling0"); // for NLog

        public static void Main(string[] args)
        {
            /*
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
            */
            //
            //BasicConfigurator.Configure();
            //XmlConfigurator.Configure();
            //
            //log.Trace("NLOG: Trace Level test");
            //log.Debug("2*Debug Level test");
            //log.Info("2*Info Level");
            //log.Warn("2*Warn Level");
            //log.Warn("test");
            //log.Error("2*Error Level test");
            //log.Error("3*Error Level");
            //log.Fatal("2*Fatal Level");
            //
            Console.WriteLine("Application Done");
            //
            // 1. Classic Constructor.
            //User user = new User("username1", "password1", "orgPin1", "databaseName1", "email1", "address1");
            //Console.WriteLine(user);
            //
            // 2. Default Constructor and Setters
            //User user = new User();
            //user.SetUsername("username2");
            //user.SetPassword("password2");
            //user.SetOrgPin("orgPin2");
            //user.SetDatabaseName("databaseName2");
            //user.SetEmail("email2");
            //user.SetAddress("address2");
            //Console.WriteLine(user);
            //
            // 3. Add Fluent Interface
            //User user = new User()
            //    .SetUsername("username2")
            //    .SetPassword("password2")
            //    .SetOrgPin("orgPin2")
            //    .SetDatabaseName("databaseName2")
            //    .SetEmail("email2")
            //    .SetAddress("address2");
            //Console.WriteLine(user);
            //
            // 4. Add Static Factory
            //User user = User.Get()
            //    .SetUsername("username2")
            //    .SetPassword("password2")
            //    .SetOrgPin("orgPin2")
            //    .SetDatabaseName("databaseName2")
            //    .SetEmail("email2")
            //    .SetAddress("address2");
            //Console.WriteLine(user);
            //
            // 5. Add Builder by Interfaces
            //User user = User.Get()
            //    .SetUsername("Username5")
            //    .SetPassword("Password5")
            //    .SetOrgPin("OrgPin5")
            //    .SetDatabaseName("DatabaseName5")
            //    .SetEmail("Email5")
            //    .Build();
            //Console.WriteLine(user);
            //Console.WriteLine(user.Username);
            // Code
            //Console.WriteLine(user.SetUsername("111")); // Defect
            // Code
            //Console.WriteLine(user.Username);
            //
            // 6. Add Dependency Inversion
            //IUser user = User.Get()
            //    .SetUsername("Username5")
            //    .SetPassword("Password5")
            //    .SetOrgPin("OrgPin5")
            //    .SetDatabaseName("DatabaseName5")
            //    .SetEmail("Email5")
            //    .Build();
            //Console.WriteLine(user.Username);
            //Console.WriteLine(user.SetUsername("111")); // Compile Error
            //Console.WriteLine(((User)user).SetUsername("111")); // Code Smell
            //Console.WriteLine(user.Username);
            //
            // 7. Add Repository
            // 8. Add Singletone
            //IUser user = UserRepository.Get().Admin();
            //Console.WriteLine(user.Username);
            //
            //StreamReader reader = new StreamReader("D:\\file.txt");
            //string line;
            //while ((line = reader.ReadLine()) != null)
            //{
            //    Console.WriteLine("line: " + line);
            //}
            //reader.Close();
            //
            //using (StreamReader reader = new StreamReader("D:\\file.txt"))
            //{
            //    string line;
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        Console.WriteLine("line: " + line);
            //    }
            //}
            //
            //using (StreamWriter writer = new StreamWriter("D:\\info.txt"))
            //using (StreamWriter writer = new StreamWriter("D:\\info.txt", true)) // Append
            //{
            //    writer.Write("Word 110 ");
            //    writer.WriteLine("word 210");
            //    writer.WriteLine("Line 310");
            //}
            //
            //string file = File.ReadAllText("D:\\file.txt");
            //Console.WriteLine(file);
            //
            //string[] lines = File.ReadAllLines("D:\\file.txt");
            //foreach (string line in lines)
            //{
            //    Console.WriteLine("line: " + line);
            //}
            //
            //string[] stringArray = new string[]
            //{
            //"cat",
            //"dog",
            //"arrow"
            //};
            //File.WriteAllLines("D:\\file.txt", stringArray);
            //
            //File.AppendAllText("D:\\file.txt", "\nfirst part\n");
            //
            //string startupPath = System.IO.Directory.GetCurrentDirectory();
            //string startupPath = Environment.CurrentDirectory;
            //string startupPath = System.IO.Path.GetFullPath(".\\");
            //string startupPath = new Program().GetType().Assembly.Location;
            string startupPath = AppDomain.CurrentDomain.BaseDirectory;
            //string startupPath = Directory.GetCurrentDirectory();
            //string startupPath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(Program)).CodeBase);
            Console.WriteLine("startupPath = " + startupPath);
            //
            string filename = "allureConfig.json";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string allureConfigPath = path.Remove(path.IndexOf("bin")) + filename;
            //FileInfo allureConfig = new FileInfo(allureConfigPath);
            if (File.Exists(path + filename))
            {
                File.Delete(path + filename);
            }
            //allureConfig.CopyTo(path + filename);
            File.Copy(allureConfigPath, path + filename);
        }
    }
}
