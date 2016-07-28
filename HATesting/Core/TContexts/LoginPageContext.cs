using Core.POMs;

namespace Core.TContexts
{
    public class LoginPageContext : BaseContext
    {
        public LoginPageContext() { }

        public LoginPage LoginPage { get { return Instance<LoginPage>(); } }
        
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
            this.LoginPage.ButtonSubmit.Click();
            return this;
        }
    }
}
