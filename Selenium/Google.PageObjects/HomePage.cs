using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace Google.PageObjects
{
    public class HomePage : PageObject
    {
        private static readonly IDictionary<string, string> GoogleHomeUris = new Dictionary<string, string>
        {
            {"US", "https://www.google.com"},
            {"GB", "https://www.google.co.uk"}
        };

        private static class Identifiers
        {
            internal static class Ids
            {
                public const string SearchBox = "lst-ib";
                public const string ResultStatistics = "resultStats";
            }           
        }

        public static HomePage NavigateTo(IWebDriver webdriver, string countryCode = "US")
        {
            if (!GoogleHomeUris.ContainsKey(countryCode))
                throw new ArgumentOutOfRangeException(nameof(countryCode), $"");

            webdriver.Navigate().GoToUrl(GoogleHomeUris[countryCode]);
            return new HomePage(webdriver);
        }

        protected HomePage(IWebDriver webDriver) : base(webDriver)
        {
            
        }

        public ResultsPage Google(string searchTerm)
        {
            SearchFor(searchTerm);
            WaitFor(d => d.FindElement(By.Id(Identifiers.Ids.ResultStatistics)));
            return ResultsPage.From(WebDriver);
        }

        public ResultsPage Google(string site, string searchTerm)
        {
            return Google($"site:{site} {searchTerm}");
        }

        private void SearchFor(string thingToGoogle)
        {
            var searchBox = WebDriver.FindElement(By.Id(Identifiers.Ids.SearchBox));
            searchBox.SendKeys(thingToGoogle);
            searchBox.SendKeys(Keys.Return);
        }
    }
}
