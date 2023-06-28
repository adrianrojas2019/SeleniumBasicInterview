using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace SeleniumBasic1
{
    class ParallelGoogleTests : SeleniumLambdaBase
    {

        GooglePage googlePage;

        public ParallelGoogleTests(string browser, string version, string os, string name) : base(browser, version, os, name)
        {
        }

        [OneTimeSetUp]
        public void SetupOnce()
        {
            googlePage = new GooglePage(driver);
        }

        //[SetUp]
        //public void Setup()
        //{
        //    dynamic capability = GetBrowserOptions(_browser);

        //    capability.BrowserVersion = "latest";
        //    Dictionary<string, object> ltOptions = new Dictionary<string, object>();
        //    ltOptions.Add("username", this.userName);
        //    ltOptions.Add("accessKey", this.accessKey);
        //    ltOptions.Add("project", "Selenium Basic Demo Lambda Test");
        //    ltOptions.Add("build", "Parallel Selenium Basic Testing");
        //    ltOptions.Add("sessionName", "C# Selenium Basic Test");
        //    ltOptions.Add("w3c", true);
        //    ltOptions.Add("plugin", "c#-c#");
        //    ltOptions.Add("platformName", _os);
        //    ltOptions.Add("name", _name);
        //    capability.AddAdditionalOption("LT:Options", ltOptions);

        //    _driver = new RemoteWebDriver(new Uri("http://hub.lambdatest.com/wd/hub/"), capability);
        //    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        //    Thread.Sleep(3000);
        //    Console.WriteLine($"Printing parameters {_browser}: {_version} : {_os} : {userName} : {accessKey}");
        //    googlePage = new GooglePage(_driver);
        //}

        //private dynamic GetBrowserOptions(string browserName)
        //{
        //    if (browserName == "Chrome")
        //        return new ChromeOptions();
        //    if (browserName == "Firefox")
        //        return new FirefoxOptions();
        //    if (browserName == "MicrosoftEdge")
        //        return new EdgeOptions();
        //    if (browserName == "Safari")
        //        return new SafariOptions();
        //    //if non, return ChromeOptions
        //    return new ChromeOptions();
        //}

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
