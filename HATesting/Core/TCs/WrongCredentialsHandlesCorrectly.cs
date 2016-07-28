using Core.POMs;
using Core.TContexts;
using Core.Verification;
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
            GeneralVerifications acceptance = new GeneralVerifications();
            LoginPage logPage = BaseContext.Instance<LoginPageContext>().LoginPage;

            BaseContext.Instance<LoginPageContext>()
                .SetEMail(email)
                .SetPassword(password)
                .ClickButtonSubmit()
                .Verify<LoginPageContext>(() =>
                {
                    acceptance.IsAlertMessageDisplayed(logPage.WrongCredsMessage, email);
                    acceptance.IsMessageCorrect(logPage.WrongCredsMessage, expectedWarningMessage);
                })
                .Wait<LoginPageContext>(5000)
                ;
        }
    }
}
