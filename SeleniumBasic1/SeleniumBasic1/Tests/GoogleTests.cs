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

        [Test]
        public void LaunchChrome()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");

            //Capture the Title
            var title = driver.Title;
            Console.WriteLine("Page Title: ");
            Console.WriteLine(title);

            var url = driver.Url;
            Console.WriteLine("Page URL: ");
            Console.WriteLine(url);


            var pageSource = driver.PageSource;
            Console.WriteLine("Page Source: ");
            Console.WriteLine(pageSource);
            Thread.Sleep(3000);

            driver.Close();

        }

    }
}
