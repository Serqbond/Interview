using Core.Verification;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;

namespace Core.TCs
{
    public class BaseTestCase
    {
        protected IWebDriver driver;
        protected GeneralVerifications generalVerificationsAceptance = new GeneralVerifications();
        private string baseUrl = ConfigurationManager.AppSettings["TargetUrl"];

        [SetUp]
        public void SetupTest()
        {
            CreateDriver();
        }

        [TearDown]
        public void TeardownTest()
        {
            driver.Quit();
        }

        /// <summary>
        /// Factory metog for creating specified driver
        /// </summary>
        /// <returns></returns>
        private void CreateDriver()
        {
            var driverToUse = Get<DriverToUse>("Driver");
            {
                switch (driverToUse)
                {
                    case DriverToUse.Chrome:
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("start-maximized");
                        driver = new ChromeDriver(chromeOptions);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                        break;
                    case DriverToUse.Firefox:
                        driver = new FirefoxDriver();
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            driver.Navigate().GoToUrl(baseUrl);
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

