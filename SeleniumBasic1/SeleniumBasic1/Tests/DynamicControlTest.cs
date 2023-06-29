using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumBasic1
{
    class DynamicControlTest : SeleniumTestBase
    {
        DynamicPage dynamicPage;

        [OneTimeSetUp]
        public void SetupOnce()
        {
            dynamicPage = new DynamicPage(driver);
        }

        [Test]
        public void ClickOnRemoveButton()
        {
            dynamicPage.GoToPage();
            dynamicPage.ClickOnRemoteButton();
            Thread.Sleep(5000);
            dynamicPage.IsMessageDisplayed("It's gone!");

        }

        [Test]
        public void ClickOnEnabledButton()
        {
            dynamicPage.GoToPage();
            dynamicPage.ClickOnEnabledButton();
            Thread.Sleep(5000);
            dynamicPage.IsMessageDisplayed("It's enabled!");
        }
    }
}
