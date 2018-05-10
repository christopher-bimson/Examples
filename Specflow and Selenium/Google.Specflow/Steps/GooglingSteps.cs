using FluentAssertions;
using Google.PageObjects;
using Google.Specflow.Selenium;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace Google.Specflow.Steps
{
    [Binding]
    public class GooglingSteps
    {
        private readonly SeleniumContext seleniumContext;

        public GooglingSteps(SeleniumContext seleniumContext)
        {
            this.seleniumContext = seleniumContext;
        }

        [Given(@"a user is on the Google UK homepage")]
        public void GivenAUserIsOnTheGoogleUKHomepage()
        {
            Current<HomePage>.Value = 
                HomePage.NavigateTo(seleniumContext.WebDriver, "GB");
        }
        
        [When(@"the user googles ""(.*)""")]
        public void WhenTheUserGoogles(string term)
        {
            Current<ResultsPage>.Value =
                Current<HomePage>.Value.Google(term);
        }
        
        [Then(@"the top google result is ""(.*)""")]
        public void ThenTheTopGoogleResultIs(string url)
        {
            Current<ResultsPage>
                .Value
                .Results
                .Any()
                .Should()
                .BeTrue("there should be at least one google result.");

            Current<ResultsPage>
                .Value
                .Results
                .First()
                .Should()
                .Be(url);
        }

        [When(@"the user googles the site ""(.*)"" for ""(.*)""")]
        public void WhenTheUserGooglesOnTheSite(string site, string term)
        {
            Current<ResultsPage>.Value =
                Current<HomePage>.Value.Google(site, term);
        }

        [Then(@"all google results are from ""(.*)""")]
        public void ThenAllGoogleResultsAreFrom(string url)
        {
            Current<ResultsPage>
                .Value
                .Results
                .Any()
                .Should()
                .BeTrue("there should be at least one google result.");

            Current<ResultsPage>
                .Value
                .Results
                .All(result => result.Contains(url))
                .Should()
                .BeTrue($"all results should be from {url}.");
        }

    }
}
