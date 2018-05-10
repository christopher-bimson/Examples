using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace Google.PageObjects
{
    public class ResultsPage : PageObject
    {
        private static class Identifiers
        {
            internal static class Classes
            {
                internal const string ResultContainer = "g";
            }
        }

        public static ResultsPage From(IWebDriver webDriver)
        {
            return new ResultsPage(webDriver);
        }

        protected ResultsPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        /// <remarks>
        /// Returning search results as strings is a simplification for illustrative purposes.
        /// </remarks>
        public IEnumerable<String> Results
        {
            get
            {
                var resultDivs = WebDriver.FindElements(By.ClassName(Identifiers.Classes.ResultContainer));
                foreach (var resultDiv in resultDivs)
                {
                    var result = String.Empty;
                    try
                    {
                        var citation = resultDiv.FindElement(By.TagName("cite"));
                        result = citation.Text;
                    }
                    catch (NoSuchElementException)
                    {
                        result = String.Empty;
                    }
                    yield return result;
                }
            }
        }
    }
}
