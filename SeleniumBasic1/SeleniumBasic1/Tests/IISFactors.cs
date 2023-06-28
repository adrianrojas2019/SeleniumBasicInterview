using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumBasic1
{
    class ISSFactors : SeleniumTestBase
    {
        ISSFactorPage iISFactorPage;

        Menu labels;

        [OneTimeSetUp]
        public void SetupOnce()
        {
            iISFactorPage = new ISSFactorPage(driver);
            labels = new Menu();
        }
        [Test]
        public void VerifyIISFactorTitle()
        {
            iISFactorPage.GoToPage();
            iISFactorPage.GoToMenuPage(labels.IIS_Factors);
            Assert.That(iISFactorPage.IsTitleDisplayedOnPage(), Is.True);
            //Wait until parametric-modal has been closed or click on Agree button
        }
    }
}
