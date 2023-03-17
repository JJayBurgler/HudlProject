using System;
using System.Diagnostics.Contracts;
using OpenQA.Selenium;

namespace Hudl.PageObjects.Login
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement Email_Input()
        {
            return driver.FindElement(By.CssSelector("[data-qa-id='email-input']"));
        }

        public IWebElement Password_Input()
        {
            return driver.FindElement(By.CssSelector("[data-qa-id='password-input']"));
        }

        public IWebElement Login_Button()
        {
            return driver.FindElement(By.CssSelector("[data-qa-id='login-btn']"));
        }

        public IWebElement LoginWithOrg_Button()
        {
            return driver.FindElement(By.CssSelector("[data-qa-id='log-in-with-organization-btn']"));
        }

        public IWebElement Error_Text()
        {
            return driver.FindElement(By.CssSelector("[data-qa-id='error-display']"));
        }

        public IWebElement SignUp_Link()
        {
            return driver.FindElement(By.XPath("//a[contains(text(),'Sign up')]"));
        }

        public IWebElement NeedHelp_Link()
        {
            return driver.FindElement(By.CssSelector("[data-qa-id='need-help-link']"));
        }

        public IWebElement BackArrow_Button()
        {
            return driver.FindElement(By.XPath("//*[contains(@class, 'backIconContainer')]"));
        }

        /// <summary>
        /// basic login function to be used in tests
        /// </summary>
        /// <param name="email">users email</param>
        /// <param name="password">users password</param>
        public void Login_Function (string email, string password)
        {
            this.Email_Input().SendKeys(email);
            this.Password_Input().SendKeys(password);
            this.Login_Button().Click();
        }
    }
}
