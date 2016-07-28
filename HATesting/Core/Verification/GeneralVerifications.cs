using NUnit.Framework;
using OpenQA.Selenium;

namespace Core.Verification
{
    public class GeneralVerifications : BaseVerification
    {
        /// <summary>
        /// Verifies that message is correct
        /// </summary>
        /// <param name="element"></param>
        /// <param name="expectedText"></param>
        public void IsMessageCorrect(IWebElement element, string expectedText)
        {            
            Assert.AreEqual(expectedText, element.GetAttribute("innerText"));
        }

        /// <summary>
        /// verifies that alert message is displayed to user
        /// </summary>
        /// <param name="element"></param>
        /// <param name="passedArgs"></param>
        public void IsAlertMessageDisplayed(IWebElement element, string passedArgs)
        {
            Assert.IsTrue(element.Displayed, @"Expected that element is displayed, but it is not. Last Passed arg is {0}", passedArgs);            
        }
    }
}
