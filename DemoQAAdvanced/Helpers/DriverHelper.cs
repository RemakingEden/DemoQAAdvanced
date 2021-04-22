using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;

namespace DemoQAAdvanced.Helpers
{
    class DriverHelper
    {
        private IWebDriver driver;
        public IWebDriver DriverSetup(ScenarioContext scenarioContext)
        {
            scenarioContext.TryGetValue("Browser", out var browser);
            switch (browser)
            {
                case "Chrome":
                    driver = this.SetupChromeDriver();
                    break;
                case "Firefox":
                    driver = this.SetupFirefoxDriver();
                    break;
                default:
                    driver = this.SetupChromeDriver();
                    break;
            }
            return driver;
        }
        public Actions ActionSetup()
        {
            var action = new Actions(driver);
            return action;
        }
      
        private IWebDriver SetupChromeDriver()
        {
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return driver;
        }

        private IWebDriver SetupFirefoxDriver()
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
