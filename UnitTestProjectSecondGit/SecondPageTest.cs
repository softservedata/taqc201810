using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProjectSecondGit.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace UnitTestProjectSecondGit
{
    [AllureNUnit]
    [AllureDisplayIgnored]
    [TestFixture]
    public class SecondPageTest : TestRunner
    {
        //private static string AllureConfigDir = Environment.GetEnvironmentVariable("USERPROFILE")
        //    + @"\Documents\Visual Studio 2015\Projects\UnitTestProjectSecondGit\UnitTestProjectSecondGit\";

        // DataProvider
        private static readonly object[] UserCredential =
        {
            //UserRepository.GetOBAdmin()
            UserRepository.Get().OBAdmin()
        };

        //[TestMethod]
        //[Test, TestCaseSource(nameof(UserCredential))]
        public void VerifyLogin(User user)
        {
            log.Info("START VerifyLogin with " + user);
            StartApplication()
                .SuccessLogin(user)
                .Logout();
            log.Info("DONE VerifyLogin");
        }

        [Test]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureOwner("User_Owner")]
        [AllureParentSuite("With_parameters_ParentSuite")]
        [AllureSuite("Passed_Suite")]
        [AllureSubSuite("NoAssert_SubSuite")]
        [AllureEpic("Retry_Epic")]
        [AllureFeature("RetrySmall_Feature")]
        [AllureLink("softserve_ITA_Link", "https://softserve.academy/")]
        public void SoftserveAcademy()
        {
            log.Info("START SoftserveAcademy");
            log.Info("ThreadID= " + Thread.CurrentThread.ManagedThreadId);
            //
            IWebDriver driver;
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // by default = 0
            //
            driver.Navigate().GoToUrl("https://softserve.academy/");
            Thread.Sleep(1000); // DO NOT USE
            //
            driver.FindElement(By.LinkText("Log in")).Click();
            Thread.Sleep(1000); // DO NOT USE
            //
            //IWebElement username = driver.FindElement(By.Id("username"));
            //
            //username.Click();
            //username.Clear();
            //username.SendKeys("Hello2");
            //Thread.Sleep(2000); // DO NOT USE
            //
            // CODE ... JS Refresh WebElement
            //driver.Navigate().Refresh();
            //
            //username.Click();
            //username.Clear();
            //username.SendKeys("Hello");
            //Thread.Sleep(2000); // DO NOT USE
            //
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("Hello2");
            Thread.Sleep(2000); // DO NOT USE
            //
            // CODE ... JS Refresh WebElement
            //driver.Navigate().Refresh();
            //
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("Hello");
            Thread.Sleep(2000); // DO NOT USE
            //
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("qwerty");
            Thread.Sleep(2000); // DO NOT USE
            //
            driver.Quit();
            log.Info("DONE SoftserveAcademy");
        }

    }
}
