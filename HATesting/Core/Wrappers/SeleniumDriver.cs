using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core.DriverWrapper
{
    /// <summary>
    /// Class that gets specified in app.config driver
    /// </summary>
    public class SeleniumDriver
    {
        private IWebDriver driver;
        private string baseUrl = ConfigurationManager.AppSettings["TargetUrl"];
        public IWebDriver Driver{get {return driver==null ? null: Create();}}
        public static IWebDriver OneDriver { get; set; } 
   
        /// <summary>
        /// Factory metog for creating specified driver
        /// </summary>
        /// <returns></returns>
        public IWebDriver Create()
        {
            if (driver == null)
            {
                var driverToUse = Get<DriverToUse>("Driver");
                {
                    switch (driverToUse)
                    {
                        case DriverToUse.Chrome:
                            driver = new ChromeDriver(Path.Combine(Path.GetDirectoryName(Assembly.GetAssembly(typeof(SeleniumDriver)).Location), "Drivers"));
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }

                driver.Manage().Window.Maximize();
                var timeouts = driver.Manage().Timeouts();
                timeouts.ImplicitlyWait(TimeSpan.FromSeconds(10));
                timeouts.SetPageLoadTimeout(TimeSpan.FromSeconds(30));
                driver.Navigate().GoToUrl(baseUrl);
            }

            return driver;
        }

        /// <summary>
        /// Get Data from app.config
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        private static T Get<T>(string name)
        {
            var value = ConfigurationManager.AppSettings[name];
            if (typeof(T).IsEnum)
            {
                return (T)Enum.Parse(typeof(T), value);
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }  
      
        /// <summary>
        /// resets driver to launch multiple tests
        /// </summary>
        public void CleanDriver()
        {
            try
            {
                driver.Quit();
                driver.Close();
                driver.Dispose();                
                driver = null;
            }
            catch
            {                
            }
        }
    }

    /// <summary>
    /// Browsers list
    /// </summary>
    public enum DriverToUse
    {
        InternetExplorer,
        Chrome,
        Firefox,
        Opera,
        Safari
    }
}
