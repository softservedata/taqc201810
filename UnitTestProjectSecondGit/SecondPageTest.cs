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

namespace UnitTestProjectSecondGit
{
    //[TestFixture]
    public class SecondPageTest : TestRunner
    {
        // DataProvider
        private static readonly object[] UserCredential =
        {
            UserRepository.GetOBAdmin()
        };

        [TestMethod]
        [Test, TestCaseSource(nameof(UserCredential))]
        public void VerifyLogin(User user)
        {
            log.Info("START VerifyLogin with " + user);
            StartApplication()
                .SuccessLogin(user)
                .Logout();
            log.Info("DONE VerifyLogin");
        }

    }
}
