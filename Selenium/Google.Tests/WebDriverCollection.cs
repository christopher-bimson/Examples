using Xunit;

namespace Google.Tests
{
    /// <remarks>
    /// This ensures the WebDriver instance is reused across tests that are part of this collection.
    /// </remarks>
    [CollectionDefinition("Web Driver Tests")]
    public class WebDriverCollection : ICollectionFixture<WebDriverFixture>
    {
        
    }
}