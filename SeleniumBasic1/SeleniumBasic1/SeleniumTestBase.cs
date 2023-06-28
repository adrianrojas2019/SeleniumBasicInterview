using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace SeleniumBasic1
{
    public abstract class SeleniumTestBase
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void CreateDriver()
        {
            driver = new ChromeDriver();
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
    }
}
