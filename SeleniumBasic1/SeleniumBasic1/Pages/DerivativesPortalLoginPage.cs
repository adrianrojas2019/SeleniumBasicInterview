using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBasic1
{
    class DerivativesPortalLoginPage
    {
        private IWebDriver driver;

        public DerivativesPortalLoginPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public IWebElement LoginButton => driver.FindElement(By.XPath("(//a[contains(@class,'parametric-link')])[5]"));
        //UserName
        public IWebElement UserName => driver.FindElement(By.Id("ppaLoginUsername"));

        //Password
        public IWebElement Password => driver.FindElement(By.Id("ppaLoginPassword"));
        //Login Portal Button
        public IWebElement LoginPortalButton => driver.FindElement(By.CssSelector("button[class='btn btn-primary']"));
        //Invalid error message
        public IWebElement InvalidLoginCredentials => driver.FindElement(By.CssSelector(".text-danger.text-center.mb-3"));


        private string url = "https://www.parametricportfolio.com/";

        public bool IsOnResultsPage()
        {
            var allWindowHandles = driver.WindowHandles;

            Thread.Sleep(2000);
            driver.SwitchTo().Window(allWindowHandles[1]);
            Thread.Sleep(2000);
            return driver.Url.Contains("https://portal.parametricportfolio.com/login");
        }

        public void ClickOnLoginButton()
        {
            LoginButton.Click();
        }

        public string addInvalidCredentials(string userName, string password)
        {
            var allWindowHandles = driver.WindowHandles;

            Thread.Sleep(2000);
            driver.SwitchTo().Window(allWindowHandles[1]);
            Thread.Sleep(2000);
            //Get and send username
            Console.WriteLine("TEST: " + userName);
            UserName.SendKeys(userName);
            Thread.Sleep(1000);
            Password.SendKeys(password);
            Thread.Sleep(1000);
            //Clilck on Login Portal Button
            LoginPortalButton.Click();
            Thread.Sleep(1000);
            return InvalidLoginCredentials.Text;
        }
    }
}
