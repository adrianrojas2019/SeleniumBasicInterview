using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumBasic1
{
    class ParametricsLoginDerivativesPortal : SeleniumTestBase
    {
        HomeLoginPage loginPage;
        DerivativesPortalLoginPage loginDerivativesPortal;

        [OneTimeSetUp]
        public void SetupOnce()
        {
            loginPage = new HomeLoginPage(driver);
            loginDerivativesPortal = new DerivativesPortalLoginPage(driver);
        }

        [Test]
        public void ClickOnLoginDerivativesPortal()
        {
            loginPage.GoToPage();
            loginPage.ClickOnLoginButton();
            Assert.That(loginPage.IsOnResultsPage(), Is.True);

            //Click on SMA Portal Login Button
            loginDerivativesPortal.ClickOnLoginButton();
            Console.WriteLine("TEST");
            Thread.Sleep(5000);

            Assert.That(loginDerivativesPortal.IsOnResultsPage(), Is.True);
        }

        [Test]
        public void addInvalidCredentials() 
        {
            loginPage.GoToPage();
            loginPage.ClickOnLoginButton();
            Assert.That(loginPage.IsOnResultsPage(), Is.True);

            //Click on SMA Portal Login Button
            loginDerivativesPortal.ClickOnLoginButton();
            Console.WriteLine("TEST");
            Thread.Sleep(5000);
            Assert.That(loginDerivativesPortal.addInvalidCredentials("arojas", "pwd"), Is.EqualTo("Invalid login credentials"));
        }
    }
}
