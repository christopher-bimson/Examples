using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Google.Specflow.Selenium
{
    public class SeleniumContext
    {
        public IWebDriver WebDriver { get; private set; }

        public SeleniumContext()
        {
            //It would be wise to make the choice of 
            //IWebDriver implementation to use configurable
            //so your tests are not statically bound to one browser
            WebDriver = new ChromeDriver();
        }
    }
}
