
using OpenQA.Selenium;

namespace Hudl.PageObjects.Home
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement Main_Section()
        {
            return driver.FindElement(By.CssSelector("#koMain"));
        }
    }
}
