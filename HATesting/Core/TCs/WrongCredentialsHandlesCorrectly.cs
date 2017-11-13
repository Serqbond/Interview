using Core.TContexts;
using NUnit.Framework;

namespace Core.TCs
{
    [TestFixture]
    public class WrongCredentialsHandlesCorrectly : BaseTestCase
    {
        [Test]
        public void NotExistingUserCredentialsHandlesCorrectly()
        {
            string email = "boo@gmail.com";
            string password = "123";            
            string expectedWarningMessage = @"Неверный адрес электронной почты или пароль. Попробуйте еще раз.";
            var LoginPageContext = new LoginPageContext(driver);

            LoginPageContext
                .SetEMail(email)
                .SetPassword(password)
                .ClickButtonSubmit()
                .Verify(() =>
                {
                    generalVerificationsAceptance.IsAlertMessageDisplayed(LoginPageContext.LoginPage.WrongCredsMessage, email);
                    generalVerificationsAceptance.IsMessageCorrect(LoginPageContext.LoginPage.WrongCredsMessage, expectedWarningMessage);
                }, LoginPageContext)
                .Wait<LoginPageContext>(LoginPageContext, 5000)
                ;
        }
    }
}
