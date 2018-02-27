using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Google.Tests
{
    public class WebDriverFixture : IDisposable
    {
        private static readonly Lazy<IWebDriver> Singleton = new Lazy<IWebDriver>(DriverFactory);

        private static IWebDriver DriverFactory()
        {
            //It would be wise to make the WebDriver implementation configurable, so 
            //the tests can switch between broser without recompilation.
            return new ChromeDriver();
        }

        public IWebDriver WebDriver => Singleton.Value;


        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                WebDriver.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}