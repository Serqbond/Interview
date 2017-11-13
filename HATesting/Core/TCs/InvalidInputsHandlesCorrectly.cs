using System.Collections.Generic;
using Core.TContexts;
using Core.Verification;
using NUnit.Framework;

namespace Core.TCs
{
    [TestFixture]
    public class InvalidInputsHandlesCorrectly : BaseTestCase
    {
        [Test]
        public void InvalidEmailEnterHandlesCorrectly()
        {
            List<string> invalidEmails = new List<string>() {"boo", "boo@gmail", "boo@gmail.com.com", "boo@boo@gmail.com"};
            
            string expectedWarningMessage = @"Пожалуйста, введите корректный адрес электронной почты.";
            var LoginPageContext = new LoginPageContext(driver);

            LoginPageContext
                .ClearEmail()
                .SetEMail(invalidEmails[0])
                .SetPassword("boo")
                .Verify(() => generalVerificationsAceptance
                .IsAlertMessageDisplayed(LoginPageContext.LoginPage.WrongEmailMessage, invalidEmails[0]), LoginPageContext)
                .Verify(() => generalVerificationsAceptance
                .IsMessageCorrect(LoginPageContext.LoginPage.WrongEmailMessage, expectedWarningMessage), LoginPageContext)
                .ClearPassword()                  
                .Wait(LoginPageContext, 5000)
                ;
        }

        [Test]
        public void EmptyEmailHandlesCorrectly()
        {
            string empty = string.Empty;            
            string expectedWarningMessage = @"Это поле необходимо заполнить.";
            var LoginPageContext = new LoginPageContext(driver);

            LoginPageContext
                .ClearEmail()
                .SetEMail(empty)
                .SetPassword("boo")
                .ClickButtonSubmit()
                .Verify(() => generalVerificationsAceptance
                .IsAlertMessageDisplayed(LoginPageContext.LoginPage.WrongEmailMessage, empty), LoginPageContext)
                .Verify(() => generalVerificationsAceptance
                .IsMessageCorrect(LoginPageContext.LoginPage.WrongEmailMessage, expectedWarningMessage), LoginPageContext)
                ;
        }
    }
}
