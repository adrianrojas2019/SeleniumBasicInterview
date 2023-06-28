using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace SeleniumBasic1
{
    [TestFixture("Safari", "13.0", "MacOS Catalina", "Safari14")]
    [TestFixture("Chrome", "114", "Windows 10", "Chrome")]
    [TestFixture("Firefox", "114", "Windows 10", "Firefox114")]
    [TestFixture("MicrosoftEdge", "114", "Windows 10", "Edge114")]
    public abstract class SeleniumLambdaBase
    {
        protected IWebDriver driver;
        private string _browser;
        private string _version;
        private string _os;
        private string _name;
        private string userName;
        private string accessKey;

        public SeleniumLambdaBase(string browser, string version, string os, string name)
        {
            _browser = browser;
            _version = version;
            _os = os;
            _name = name;
            userName = "rojasadrian";
            accessKey = "n3xpYLO1dftlV2CK18KVJziZX192xw8XRez1Kf6OhkxrV9icdj";
        }

        [OneTimeSetUp]
        public void CreateDriver()
        {
            dynamic capability = GetBrowserOptions(_browser);

            capability.BrowserVersion = "latest";
            Dictionary<string, object> ltOptions = new Dictionary<string, object>();
            ltOptions.Add("username", this.userName);
            ltOptions.Add("accessKey", this.accessKey);
            ltOptions.Add("project", "Selenium Basic Demo Lambda Test");
            ltOptions.Add("build", "Parallel Selenium Basic Testing");
            ltOptions.Add("sessionName", "C# Selenium Basic Test");
            ltOptions.Add("w3c", true);
            ltOptions.Add("plugin", "c#-c#");
            ltOptions.Add("platformName", _os);
            ltOptions.Add("name", _name);
            capability.AddAdditionalOption("LT:Options", ltOptions);

            driver = new RemoteWebDriver(new Uri("http://hub.lambdatest.com/wd/hub/"), capability);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Thread.Sleep(3000);
            Console.WriteLine($"Printing parameters {_browser}: {_version} : {_os} : {userName} : {accessKey}");
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            try
            {
                driver.Close();
            }
            finally
            {
                driver.Quit();
            }
        }
        private dynamic GetBrowserOptions(string browserName)
        {
            if (browserName == "Chrome")
                return new ChromeOptions();
            if (browserName == "Firefox")
                return new FirefoxOptions();
            if (browserName == "MicrosoftEdge")
                return new EdgeOptions();
            if (browserName == "Safari")
                return new SafariOptions();
            //if non, return ChromeOptions
            return new ChromeOptions();
        }
    }
}
