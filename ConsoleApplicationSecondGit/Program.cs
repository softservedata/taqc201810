using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationSecondGit
{
    public class Program
    {
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
            Console.WriteLine("Application Done");
        }
    }
}
