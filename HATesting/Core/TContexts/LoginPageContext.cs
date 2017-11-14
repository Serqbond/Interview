using Core.POMs;
using OpenQA.Selenium;

namespace Core.TContexts
{
    public class LoginPageContext : BaseContext
    {

        public LoginPage LoginPage { get; private set; }

        public LoginPageContext(IWebDriver driver) : base (driver)
        {
            LoginPage = new LoginPage(driver);
        }        
        
        public LoginPageContext SetEMail(string email)
        {
            this.LoginPage.EMailField.SendKeys(email);
            return this;
        }        

        public LoginPageContext ClearEmail()
        {
            this.LoginPage.EMailField.Clear();
            return this;
        }
        
        public LoginPageContext SetPassword(string password)
        {
            this.LoginPage.PasswordField.SendKeys(password);
            return this;
        }

        public LoginPageContext ClearPassword()
        {
            this.LoginPage.PasswordField.Clear();
            return this;
        }
        
        public LoginPageContext ClickButtonSubmit()
        {
            try
            {
                this.LoginPage.ButtonSubmit.Click();
            }
            catch { }

            return new LoginPageContext(driver);
        }
    }
}
