using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondGit.Pages
{
    public class DropdownListComponent
    {
        private IEnumerable<IWebElement> databaseElements;

        public DropdownListComponent(IWebDriver driver, By by)
        {
            databaseElements = driver.FindElements(by);
        }

        // PageObject Atomic

        // databaseElements
        public IEnumerable<IWebElement> GetDatabaseElements()
        {
            return databaseElements;
        }

        public IWebElement GetItemByName(string name)
        {
            IWebElement result = null;
            foreach (IWebElement current in GetDatabaseElements())
            {
                Console.WriteLine("current.Text.ToLower() = " + current.Text.ToLower());
                if (current.Text.ToLower().Equals(name.ToLower()))
                {
                    result = current;
                    break;
                }
            }
            if (result == null)
            {
                throw new Exception("***Invalid database name: " + name);
            }
            return result;
        }

        public void ClickItemByName(string name)
        {
            GetItemByName(name).Click();
        }

        // Functional

        public List<string> GetAllDatabaseNames()
        {
            List<string> result = new List<string>();
            foreach (IWebElement current in GetDatabaseElements())
            {
                result.Add(current.Text);
            }
            return result;
        }

        // Business Logic
    }
}
