using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBasic1
{
    class HomeLoginPage
    {
        private IWebDriver driver;

        public HomeLoginPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public IWebElement LoginButton => driver.FindElement(By.ClassName("navDropdown__cta"));
 
        private string url = "https://www.parametricportfolio.com/";

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(url);
            //Maximize current window
            driver.Manage().Window.Maximize();
        }

        public bool IsOnResultsPage()
        {
            return driver.Url.Contains("/client-portal");
        }

        public void ClickOnLoginButton()
        {
            LoginButton.Click();
        }
    }
}
