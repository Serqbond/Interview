using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Core.POMs
{
    /// <summary>
    /// Login page controls
    /// </summary>
    public class LoginPage : BasePage 
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(this.ButtonSubmit));
        }        

        [FindsBy(How = How.Id, Using = "email", Priority = 0)]        
        public IWebElement EMailField { get; set; }

        [FindsBy(How = How.Id, Using = "password", Priority = 0)]        
        public IWebElement PasswordField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='view']//form/button")]
        public IWebElement ButtonSubmit { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@for='email']")]
        public IWebElement WrongEmailMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-danger']")]        
        public IWebElement WrongCredsMessage { get; set; }
    }
}
