using OpenQA.Selenium;
using Hudl.PageObjects.Home;
using Hudl.PageObjects.Login;
using OpenQA.Selenium.Chrome;

namespace Hudl.PageObjects
{
    /// <summary>
    /// Starting point for all pages. Also makes reading of Page Objects cleaner.
    /// </summary>
    public class Hudl
    {
        public IWebDriver driver;
        public HomePage Home;
        public LoginPage Login;

        public Hudl() 
        {
            //Ideally these env vars would get read in during ci/cd
            Environment.SetEnvironmentVariable("EMAIL","testemail");
            Environment.SetEnvironmentVariable("PASS","testpassword");
            Environment.SetEnvironmentVariable("BASEURL","https://www.hudl.com/");
            
            //can add capabilities or other browsers here as needed
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //List of pages we can use
            Login = new LoginPage(driver);
            Home = new HomePage(driver); 
        }

        /*TBD - move start up and tear down into hear so its not in every test*/
    }
}
