using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumBasic1
{
    class GoogleTests : SeleniumTestBase
    {
        GooglePage googlePage;

        [OneTimeSetUp]
        public void SetupOnce()
        {
            googlePage = new GooglePage(driver);
        }

        [Test]
        public void SearchForNothing()
        {
            //arrange
            googlePage.GoToPage();

            //act
            googlePage.SearchFor("nothing");            

            //assert
            Assert.IsTrue(googlePage.IsOnResultsPage());
        }
    }
}
