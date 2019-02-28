using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProjectSecondGit.Pages
{
    public class UserProfileDropdownComponent
    {
        private IWebDriver driver;
        //
        public IWebElement MySetting
            { get { return driver.FindElement(By.XPath("//a[text()='My Settings']")); } }
        public IWebElement LogOut
            { get { return driver.FindElement(By.XPath("//a[text()='Log Out']")); } }

        public UserProfileDropdownComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        // PageObject Atomic

        // MySetting
        public void ClickMySetting()
        {
            MySetting.Click();
        }

        // LogOut
        public void ClickLogOut()
        {
            LogOut.Click();
        }

        // Functional

        // Business Logic

    }

    public class ConfirmationLogoutAlert
    {
        private IWebDriver driver;
        //
        public IWebElement YesButton
        { get { return driver.FindElement(By.XPath("//span[text()='Yes']/../../..")); } }
        public IWebElement NoButton
        { get { return driver.FindElement(By.XPath("//span[text()='No']/../../..")); } }

        public ConfirmationLogoutAlert(IWebDriver driver)
        {
            this.driver = driver;
        }

        // PageObject Atomic

        // YesButton
        public void ClickYesButton()
        {
            YesButton.Click();
        }

        // NoButton
        public void ClickNoButton()
        {
            NoButton.Click();
        }

        // Functional

        // Business Logic
    }

    public abstract class AtopToolBarComponent
    {
        protected readonly string VALUE_ATTRIBUTE = "value";
        //
        protected IWebDriver driver;
        //
        private UserProfileDropdownComponent userProfileDropdown;
        //
        private IWebElement Headerwrapper
            { get { return driver.FindElement(By.Id("headerwrapper")); } }
        public IWebElement Home
            { get { return driver.FindElement(By.Id("mmHome")); } }
        public IWebElement Dashboards
            { get { return driver.FindElement(By.Id("mmDashboards")); } }
        public IWebElement ConfigurationCenterButton
            { get { return driver.FindElement(By.Id("mmConfigurationCenter")); } }
        public IWebElement UserProfileButton
            { get { return driver.FindElement(By.Id("mmUserName")); } }

        public AtopToolBarComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        // PageObject Atomic

        // Headerwrapper
        private void ClickHeaderwrapper()
        {
            Headerwrapper.Click();
        }

        // Home
        public string GetHomeText()
        {
            return Home.Text;
        }

        public void ClickHome()
        {
            Home.Click();
        }

        // Dashboards
        public string GetDashboardsText()
        {
            return Dashboards.Text;
        }

        public void ClickDashboards()
        {
            Dashboards.Click();
        }

        // ConfigurationCenterButton
        public void ClickConfigurationCenterButton()
        {
            ConfigurationCenterButton.Click();
        }

        // UserProfileButton
        public void ClickUserProfileButton()
        {
            // TODO
            //ClickHeaderwrapper();
            UserProfileButton.Click();
            userProfileDropdown = new UserProfileDropdownComponent(driver);
        }

        // Functional

        // Business Logic

        public LoginPage Logout()
        {
            ClickUserProfileButton();
            userProfileDropdown.ClickLogOut();
            Thread.Sleep(2000); // For Presentation ONLY
            ConfirmationLogoutAlert confirmationLogoutAlert = new ConfirmationLogoutAlert(driver);
            Thread.Sleep(2000); // For Presentation ONLY
            confirmationLogoutAlert.ClickYesButton();
            return new LoginPage(driver);
        }
    }
}
