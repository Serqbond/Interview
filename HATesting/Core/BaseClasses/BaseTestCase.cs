using Core.DriverWrapper;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Core.TCs
{    
    public class BaseTestCase
    {        
        private SeleniumDriver selDriver;         

        [SetUp]
        public void SetupTest()
        {
            selDriver = new SeleniumDriver();
            SeleniumDriver.OneDriver = selDriver.Create();
        }

        [TearDown]
        public void TeardownTest()
        {            
            selDriver.CleanDriver();
            selDriver = null;
            SeleniumDriver.OneDriver = null;                     
        }
    }
}
