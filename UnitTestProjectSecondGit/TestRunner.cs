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
using System.IO;

namespace UnitTestProjectSecondGit
{
    public abstract class TestRunner
    {
        protected static Logger log = LogManager.GetCurrentClassLogger(); // for NLog
        protected const string FOLDER_BIN = "bin";
        protected const string ALLURE_CONFIG = "allureConfig.json";

        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            PrepareAllureConfig();
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // by default 0
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
            log.Info("AfterAllMethods() done");
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

        private void PrepareAllureConfig()
        {
            string runtimePath = AppDomain.CurrentDomain.BaseDirectory;
            string sourcePath = runtimePath.Remove(runtimePath.IndexOf(FOLDER_BIN)) + ALLURE_CONFIG;
            if (File.Exists(sourcePath))
            {
                if (File.Exists(runtimePath + ALLURE_CONFIG))
                {
                    File.Delete(runtimePath + ALLURE_CONFIG);
                }
                File.Copy(sourcePath, runtimePath + ALLURE_CONFIG);
            }
            else
            {
                log.Warn("File " + sourcePath + " NOT FOUND.");
            }
        }
    }
}
