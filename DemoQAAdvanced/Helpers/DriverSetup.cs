using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace DemoQAAdvanced.Helpers
{
    class DriverSetup
    {
        private IWebDriver driver;        
        public IWebDriver SetupChromeDriver()
        {
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return driver;
        }

        public IWebDriver SetupFirefoxDriver()
        {
            var firefoxOptions = new FirefoxOptions();
            //firefoxOptions.AddArguments("headless");
            driver = new FirefoxDriver(firefoxOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return driver;
        }
    }
}
