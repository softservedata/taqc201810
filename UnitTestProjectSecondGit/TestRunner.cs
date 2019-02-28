using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProjectSecondGit.Pages;
using NLog;

namespace UnitTestProjectSecondGit
{
    public abstract class TestRunner
    {
        protected static Logger log = LogManager.GetCurrentClassLogger(); // for NLog

        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // by default 0
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl(Environment.GetEnvironmentVariable("JAZZ_URL"));
        }

        //[TearDown]
        public void TearDown()
        {
            //driver.Navigate().GoToUrl(Environment.GetEnvironmentVariable("JAZZ_URL"));
        }

        protected LoginPage StartApplication()
        {
            log.Debug("PREPARE GetOBAdmin");
            return new LoginPage(driver);
        }
    }
}
