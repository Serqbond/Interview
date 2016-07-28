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
            GeneralVerifications acceptance = new GeneralVerifications();
            string expectedWarningMessage = @"Пожалуйста, введите корректный адрес электронной почты.";

            BaseContext.Instance<LoginPageContext>()
                .Each<LoginPageContext, string>(invalidEmails, email =>
                    BaseContext.Instance<LoginPageContext>()
                    .ClearEmail()
                    .SetEMail(email)
                    .SetPassword("boo")
                    .Verify<LoginPageContext>(() =>
                    {
                        acceptance.IsAlertMessageDisplayed(BaseContext.Instance<LoginPageContext>().LoginPage.WrongEmailMessage, email); 
                        acceptance.IsMessageCorrect(BaseContext.Instance<LoginPageContext>().LoginPage.WrongEmailMessage, expectedWarningMessage); 
                    })
                    .ClearPassword()
                    )
                                
                .Wait<LoginPageContext>(5000)
                ;
        }

        [Test]
        public void EmptyEmailHandlesCorrectly()
        {
            string empty = string.Empty;
            GeneralVerifications acceptance = new GeneralVerifications();
            string expectedWarningMessage = @"Это поле необходимо заполнить.";

            BaseContext.Instance<LoginPageContext>()
                .ClearEmail()
                .SetEMail(empty)
                .SetPassword("boo")
                .ClickButtonSubmit()
                .Verify<LoginPageContext>(() => acceptance.IsAlertMessageDisplayed(BaseContext.Instance<LoginPageContext>().LoginPage.WrongEmailMessage, empty))
                .Verify<LoginPageContext>(() => acceptance.IsMessageCorrect(BaseContext.Instance<LoginPageContext>().LoginPage.WrongEmailMessage, expectedWarningMessage))
                ;
        }
    }
}
