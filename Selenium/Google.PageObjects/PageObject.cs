using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Google.PageObjects
{
    public abstract class PageObject
    {
        protected IWebDriver WebDriver { get; private set; }

        protected PageObject(IWebDriver webDriver)
        {
            WebDriver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        protected void WaitFor(Func<IWebDriver, IWebElement> condition, TimeSpan timeout)
        {
            var wait = new WebDriverWait(WebDriver, timeout);
            wait.Until(condition);
        }

        protected void WaitFor(Func<IWebDriver, IWebElement> condition)
        {
            WaitFor(condition, TimeSpan.FromSeconds(10));
        }
    }
}
