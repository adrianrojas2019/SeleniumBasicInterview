using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBasic1
{
    class DynamicPage
    {
        private IWebDriver driver;

        public DynamicPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        //public IWebElement SearchBox => driver.FindElement(By.CssSelector("input[title*=\"Search\"]"));
        //public IWebElement SearchBox => driver.FindElement(By.Name("q"));
        public IWebElement RemoveButton => driver.FindElement(By.XPath("//button[contains(text(),'Remove')]"));
        //or the same below approach get property

        //public IWebElement SearchBox
        //{
        //    get
        //    {
        //        return driver.FindElement(By.CssSelector("input[value*='Buscar con Google']"));

        //    }
        //}

        //public IWebElement SearchButton => driver.FindElement(By.CssSelector("body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf > div.FPdoLc.lJ9FBc > center > input.gNO89b"));
        // getting two elements
        //public IWebElement SearchButton => driver.FindElement(By.Name("btnK"));
       //public IWebElement SearchButton => driver.FindElement(By.CssSelector("div[class='FPdoLc lJ9FBc'] input[name='btnK']"));
        public IWebElement RemoveMessage => driver.FindElement(By.CssSelector("p[id='message']"));
        public IWebElement EnabledButton => driver.FindElement(By.XPath("//*[@id='input-example']//button"));

        private string url = "http://the-internet.herokuapp.com/dynamic_controls";

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(url);
            //Maximize current window
            driver.Manage().Window.Maximize();
        }

        public void ClickOnRemoteButton()
        {
            RemoveButton.Click();
        }

        public void ClickOnEnabledButton()
        {
            EnabledButton.Click();
        }

        public void IsMessageDisplayed(string message)
        {
            Assert.That(RemoveMessage.Text, Is.EqualTo(message));
        }
    }
}
