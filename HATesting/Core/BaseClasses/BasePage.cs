using Core.DriverWrapper;
using OpenQA.Selenium.Support.PageObjects;

namespace Core.POMs
{
    public class BasePage
    {
        public BasePage() { }        

        /// <summary>
        /// Creates POM
        /// </summary>
        /// <param name="page"></param>
        protected void InitPageElements(object page)
        {
            PageFactory.InitElements(SeleniumDriver.OneDriver, page);
        }

        
    }
}
