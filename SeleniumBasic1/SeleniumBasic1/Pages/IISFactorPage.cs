using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

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

            Thread.Sleep(5000);
            InvestorSolutionsMenu.Click();
            Thread.Sleep(5000);
            Console.WriteLine("Value is: " + pageName);
            //Then Click on Sub item {pageName} => 'Factors' notice [1] and [2] there are 2 sub menu
            var subItem  = InvestorSolutionsFactorMenuItem(pageName);

            Thread.Sleep(5000);
            Console.WriteLine("Clicked??");
            Console.WriteLine(subItem);
            subItem.Click();
        }
        public bool IsTitleDisplayedOnPage()
        {
            Console.WriteLine("Factor Title: " + FactorTitle.Text);
            string factorTitle = FactorTitle.Text;
            Thread.Sleep(5000);
            //return Assert.That(ISS_Factors_Title, Is.EqualTo(FactorTitle.Text));
            //Assert.That(FactorTitle.Text, Is.EqualTo(ISS_Factors_Title));

            return factorTitle.Contains(ISS_Factors_Title);
        }
    }
}
