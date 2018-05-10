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

        private HomePage Home
        {
            get { return ScenarioContext.Current.Get<HomePage>(); }
            set { ScenarioContext.Current.Set(value); }
        }

        private ResultsPage Results
        {
            get { return ScenarioContext.Current.Get<ResultsPage>(); }
            set { ScenarioContext.Current.Set(value); }
        }

        public GooglingSteps(SeleniumContext seleniumContext)
        {
            this.seleniumContext = seleniumContext;
        }

        [Given(@"a user is on the Google UK homepage")]
        public void GivenAUserIsOnTheGoogleUKHomepage()
        {
            Home = HomePage.NavigateTo(seleniumContext.WebDriver,
                "GB");
        }
        
        [When(@"the user googles ""(.*)""")]
        public void WhenTheUserGoogles(string term)
        {
            Results = Home.Google(term);
        }
        
        [Then(@"the top google result is ""(.*)""")]
        public void ThenTheTopGoogleResultIs(string url)
        {
            Assert.True(Results.Results.Any(), "The last google returned no results.");
            Assert.Equal(url, Results.Results.First());
        }
    }
}
