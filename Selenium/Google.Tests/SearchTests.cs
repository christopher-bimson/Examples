using System.Linq;
using FluentAssertions;
using Google.PageObjects;
using Xunit;

namespace Google.Tests
{
    [Collection("Web Driver Tests")]
    public class SearchTests : IClassFixture<WebDriverFixture>
    {
        protected WebDriverFixture Fixture { get; set; }

        public SearchTests(WebDriverFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public void Microsofts_Website_Is_First_Result_When_Googling_Microsoft()
        {
            var googleUk = HomePage.NavigateTo(Fixture.WebDriver, "GB");

            var resultsPage = googleUk.Google("microsoft");

            resultsPage.Results.First().Should().Be("https://www.microsoft.com/en-gb");
        }

        [Fact]
        public void All_Results_Should_Be_From_Microsoft_Dot_Com_When_Googling_Microsoft_Dot_Com_Specifically()
        {
            var homePage = HomePage.NavigateTo(Fixture.WebDriver);

            var results = homePage.Google("microsoft.com", "service fabric blog");

            results.Results.All(r => r.Host.Contains("microsoft.com")).Should().BeTrue();
        }
    }
}
