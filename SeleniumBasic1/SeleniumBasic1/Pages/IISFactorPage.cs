using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace SeleniumBasic1
{
    class ISSFactorPage
    {
        private IWebDriver driver;
        readonly Menu? labels;

        //declare into constant file or into each page(web page) object
        public static string ISS_Factors_Title = "Parametric's factor investing strategies provide cost-efficient, risk-controlled access to a suite of customizable strategies across US and international equities.";

        public ISSFactorPage(IWebDriver _driver)
        {
            driver = _driver;
            labels = new Menu();
        }

        public IWebElement FactorTitle => driver.FindElement(By.ClassName("parametric-container-hero-cta-full-paragraph"));
        public IWebElement InvestorSolutionsMenu => driver.FindElement(By.XPath("(//button[@class='dropdown-button'])[2]"));

        public IWebElement InvestorSolutionsFactorMenuItem(string menuItem)
        {
            return driver.FindElement(By.XPath($"(//a[@title='{menuItem}'][normalize-space()='{menuItem}'])[1]"));
        }

        private string url = "https://www.parametricportfolio.com/";


        public void GoToPage()
        {
            driver.Navigate().GoToUrl(url);
            //Maximize current window
            driver.Manage().Window.Maximize();
        }

        public void GoToMenuPage(string pageName)
        {
            //Click on Factors Item => Investor Solutions->under Institutionals Investor Solutions->Factors
            //Create menuBar class with all menu item-subitems
            //Click on Investor Solutions


            //InvestorSolutionsMenu.Click();
            //Workaround mouse over Investor Solutions Menu
            // Create an instance of the Actions class
            Actions actions = new(driver);

            // Move the mouse cursor to the element
            actions.MoveToElement(InvestorSolutionsMenu).Perform();
            Thread.Sleep(1000);
            //Then Click on Sub item {pageName} => 'Factors' notice [1] and [2] there are 2 sub menu
            InvestorSolutionsFactorMenuItem(pageName).Click();
        }
        public bool IsTitleDisplayedOnPage()
        {
            return FactorTitle.Text.Contains(ISS_Factors_Title);
        }
    }
}
