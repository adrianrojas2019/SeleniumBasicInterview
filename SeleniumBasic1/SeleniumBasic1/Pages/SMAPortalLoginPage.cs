using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBasic1
{
    class SMAPortalLoginPage
    {
        private IWebDriver driver;

        public SMAPortalLoginPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public IWebElement LoginButton => driver.FindElement(By.XPath("//a[@href='https://platform.parametricportfolio.com/account/signin']"));
 
        private string url = "https://www.parametricportfolio.com/";

        public bool IsOnResultsPage()
        {
            //string windowId = driver.CurrentWindowHandle;
            var allWindowHandles = driver.WindowHandles;

            Thread.Sleep(2000);
            driver.SwitchTo().Window(allWindowHandles[1]);
            Thread.Sleep(2000);
            return driver.Url.Contains("https://login.parametricportfolio.com/");
        }

        public void ClickOnLoginButton()
        {
            LoginButton.Click();
        }
    }
}
