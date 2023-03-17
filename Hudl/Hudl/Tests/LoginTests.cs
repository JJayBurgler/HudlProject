using OpenQA.Selenium;
using System.Diagnostics;

namespace Hudl.Tests
{
    public class LoginTests
    {
        PageObjects.Hudl Hudl;

        /// <summary>
        /// Basic Log in Test
        /// Waits for Home page and then verifies the URL is correct
        /// </summary>
        [Test]
        public void Login()
        {
            Hudl.Login.Login_Function(Environment.GetEnvironmentVariable("EMAIL"), Environment.GetEnvironmentVariable("PASS"));
            Hudl.Home.Main_Section();
            Assert.IsTrue(Hudl.driver.Url.Contains("home"));
         }
        

        /// <summary>
        /// Test to verify error is thrown when no email is supplied
        /// </summary>
        [Test]
        public void Login_NoEmail()
        {
            Hudl.Login.Login_Function("", Environment.GetEnvironmentVariable("PASS"));
            Hudl.Login.Error_Text();
            Thread.Sleep(500); //needed small wait to account for the animation, could be solved with a WaitForAnimationMethod
            Assert.IsTrue(Hudl.Login.Error_Text().Text.Contains("We didn't recognize that email and/or password."));
        }

        /// <summary>
        /// Test to verify error is thrown when no password is supplied
        /// </summary>
        [Test]
        public void Login_NoPassword()
        {
            Hudl.Login.Login_Function(Environment.GetEnvironmentVariable("EMAIL"), "");
            Hudl.Login.Error_Text();
            Thread.Sleep(500); //needed small wait to account for the animation, could be solved with a WaitForAnimationMethod
            Assert.IsTrue(Hudl.Login.Error_Text().Text.Contains("We didn't recognize that email and/or password."));
        }

        /*These next tests could be dev tests*/

        /// <summary>
        /// Test to verify signup link has the correct URL
        /// </summary>
        [Test]
        public void SignUp()
        {
            var href = Hudl.Login.SignUp_Link().GetAttribute("href");
            Assert.IsTrue(href.Contains("register/signup"));
        }

        /// <summary>
        /// Test to verify Log in with an Organization has the correct URL
        /// </summary>
        [Test]
        public void LoginWithOrg()
        {
            var href = Hudl.Login.LoginWithOrg_Button().FindElement(By.XPath("..")).GetAttribute("href");
            Assert.IsTrue(href.Contains("login/organization"));
        }

        /// <summary>
        /// Test to check that the Need help? link as the correct URL
        /// </summary>
        [Test]
        public void NeedHelp()
        {
            Hudl.Login.NeedHelp_Link().Click();
            Thread.Sleep(500); //needed small wait to account for the animation, could be solved with a WaitForAnimationMethod
            Assert.IsTrue(Hudl.driver.Url.Contains("help"));
        }

        /// <summary>
        /// Test to verify clicking back arrow takes you back to the landing page by verifying the URL
        /// </summary>
        [Test]
        public void BackToLanding()
        {
            Hudl.Login.BackArrow_Button().Click();
            TestContext.WriteLine(Hudl.driver.Url);
            Assert.IsTrue(Hudl.driver.Url.Equals(Environment.GetEnvironmentVariable("BASEURL")));
        }

        [Ignore("TBD")]
        [Test]
        public void RememberMe()
        {
            //I would need to know the intended funcionality here.
            //Is it just remembering email?
            //Or is it remembering the login?
        }

        [Ignore("TBD")]
        [Test]
        public void LoginText()
        {
            //You could verify the text on the screen is correct
            //But I think this should be a dev test
            //And I would talk with my dev to make sure it gets covered
        }

        [SetUp] 
        public void SetUp() 
        {
            Hudl = new PageObjects.Hudl();
            Hudl.driver.Navigate().GoToUrl(Environment.GetEnvironmentVariable("BASEURL") + "login");
        }

        [TearDown] 
        public void TearDown() 
        {
            Hudl.driver.Quit();
        }
    }
}
