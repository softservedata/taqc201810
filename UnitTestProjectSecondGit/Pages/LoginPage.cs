using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProjectSecondGit.Data;
using System.Threading;
using NLog;

namespace UnitTestProjectSecondGit.Pages
{
    public class LoginPage
    {
        private static Logger log = LogManager.GetCurrentClassLogger(); // for NLog
        private readonly string VALUE_ATTRIBUTE = "value";
        private readonly string DATABASE_DROPDOWN_LIST_BY_XPATH = "//li[@role='option']";
        //
        private IWebDriver driver;
        //
        // Classic Approach
        // private IWebElement username;
        //
        //private DropdownListComponent databaseDropdownList;
        //
        public IWebElement Username
            { get { return driver.FindElement(By.Id("txtUsername-inputEl")); } }
        public IWebElement Password
            { get { return driver.FindElement(By.Id("txtPassword-inputEl")); } }
        public IWebElement OrgPin
            { get { return driver.FindElement(By.Id("txtOrgPin-inputEl")); } }
        public IWebElement ComboDatabase
            { get { return driver.FindElement(By.Id("comboDatabase-inputEl")); } }
        private IWebElement ComboDatabasePlaceholder
            { get { return driver.FindElement(By.CssSelector("#comboDatabase-inputEl[placeholder='Select a database...']")); } }
        public IWebElement ComboDatabaseButton
            { get { return driver.FindElement(By.Id("comboDatabase-inputEl")); } }
        public IWebElement LoginButton
            { get { return driver.FindElement(By.Id("btnLoginButton")); } }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            // Classic Approach, Verify, if All WebElements Exist
            //username = driver.FindElement(By.Id("txtUsername-inputEl"));
        }

        // PageObject Atomic

        // Username
        public string GetUsernameText()
        {
            return Username.GetAttribute(VALUE_ATTRIBUTE);
        }

        public void ClearUsername()
        {
            Username.Clear();
        }

        public void ClickUsername()
        {
            log.Trace("\tMETHOD ClickUsername START");
            Username.Click();
            log.Trace("\tMETHOD ClickUsername DONE");
        }

        public void SetUsername(string text)
        {
            Username.SendKeys(text);
        }

        // Password
        public string GetPasswordText()
        {
            return Password.GetAttribute(VALUE_ATTRIBUTE);
        }

        public void ClearPassword()
        {
            Password.Clear();
        }

        public void ClickPassword()
        {
            Password.Click();
        }

        public void SetPassword(string text)
        {
            Password.SendKeys(text);
        }

        // OrgPin
        public string GetOrgPinText()
        {
            return OrgPin.GetAttribute(VALUE_ATTRIBUTE);
        }

        public void ClearOrgPin()
        {
            OrgPin.Clear();
        }

        public void ClickOrgPin()
        {
            OrgPin.Click();
        }

        public void SetOrgPin(string text)
        {
            OrgPin.SendKeys(text);
        }

        // ComboDatabase
        public string GetComboDatabaseText()
        {
            return ComboDatabase.GetAttribute(VALUE_ATTRIBUTE);
        }

        //public void ClearComboDatabase()
        //{
        //    ComboDatabase.Clear();
        //}

        public void ClickComboDatabase()
        {
            ComboDatabase.Click();
        }

        //public void SetComboDatabase(string text)
        //{
        //    ComboDatabase.SendKeys(text);
        //}

        // ComboDatabaseButton
        public void ClickComboDatabaseButton()
        {
            ComboDatabaseButton.Click();
        }

        // LoginButton
        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        // Functional

        private void PopulateCredentional(User user)
        {
            log.Debug("START PopulateCredentional with User: " + user);
            // 
            ClickUsername();
            ClearUsername();
            SetUsername(user.Username);
            log.Trace("\tMETHOD PopulateCredentional SetUsername DONE");
            //
            ClickPassword();
            ClearPassword();
            SetPassword(user.Password);
            log.Trace("\tMETHOD PopulateCredentional SetPassword DONE");
            //
            ClickOrgPin();
            ClearOrgPin();
            SetOrgPin(user.OrgPin);
            log.Trace("\tMETHOD PopulateCredentional SetOrgPin DONE");
            // Set Focus
            ClickComboDatabase();
            IWebElement waitElement = ComboDatabasePlaceholder;
            //
            //ClickOrgPin();
            //ClickComboDatabaseButton();
            //ClickComboDatabase();
            DropdownListComponent databaseDropdownList = new DropdownListComponent(driver, By.XPath(DATABASE_DROPDOWN_LIST_BY_XPATH));
            databaseDropdownList.ClickItemByName(user.DatabaseName);
            log.Trace("\tMETHOD PopulateCredentional SetDatabase DONE");
            //
            ClickLoginButton();
            log.Debug("DONE PopulateCredentional with User: " + user);
        }

        // Business Logic

        public HomePage SuccessLogin(User user)
        {
            log.Debug("START SuccessLogin with User: " + user);
            PopulateCredentional(user);
            return new HomePage(driver);
        }

        public LoginPage UnsuccessfulLogin(User invalidUser)
        {
            log.Debug("START UnsuccessfulLogin with User: " + invalidUser);
            PopulateCredentional(invalidUser);
            return new LoginPage(driver);
        }
    }
}
