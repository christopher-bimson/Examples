using BoDi;
using Google.Specflow.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Google.Specflow.Hooks
{
    [Binding]
    public sealed class SeleniumHooks
    {
        private static SeleniumContext seleniumContext;
        private readonly IObjectContainer objectContainer;

        public SeleniumHooks(IObjectContainer objectContainer)
        {
            if (objectContainer == null)
                throw new ArgumentNullException(nameof(objectContainer));

            this.objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            seleniumContext = new SeleniumContext();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //Why wrap the IWebDriver in this context class?
            //Because Specflow will dispose of IDisposable objects
            //that are injected into a Steps class with context injection
            //and that is not what I want. I want to save time by reusing
            //the same browser instance rather than creating a new one
            //for each scenario.
            this.objectContainer.RegisterInstanceAs(seleniumContext);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            seleniumContext.WebDriver.Dispose();
        }

    }
}
