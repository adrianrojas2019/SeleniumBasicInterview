using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumBasic1
{
    class ParametricLoginSMAPortal : SeleniumTestBase
    {
        HomeLoginPage loginPage;
        SMAPortalLoginPage loginSMAPortal;

        [OneTimeSetUp]
        public void SetupOnce()
        {
            loginPage = new HomeLoginPage(driver);
            loginSMAPortal = new SMAPortalLoginPage(driver);
        }

        [Test]
        public void ClickOnLoginSMAPortal()
        {
            loginPage.GoToPage();
            loginPage.ClickOnLoginButton();
            Assert.That(loginPage.IsOnResultsPage(), Is.True);

            //Click on SMA Portal Login Button
            loginSMAPortal.ClickOnLoginButton();
            Assert.That(loginSMAPortal.IsOnResultsPage(), Is.True);
        }
    }
}
