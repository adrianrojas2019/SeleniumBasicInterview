using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumBasic1
{
    class ParametricLoginHome : SeleniumTestBase
    {
        HomeLoginPage loginPage;

        [OneTimeSetUp]
        public void SetupOnce()
        {
            loginPage = new HomeLoginPage(driver);
        }

        [Test]
        public void ClickOnLoginHomePage()
        {
            //arrange
            loginPage.GoToPage();

            //act
            loginPage.ClickOnLoginButton();            

            //assert
            //Assert.IsTrue(loginPage.IsOnResultsPage());
            Assert.That(loginPage.IsOnResultsPage(), Is.True);
        }
    }
}
