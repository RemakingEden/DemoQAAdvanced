using BoDi;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;

namespace DemoQAAdvanced.hooks
{
    [Binding]
    public sealed class Hooks
    {
        public IObjectContainer container { get; private set; }
        private IWebDriver driver;
        public IConfiguration config { get; private set; }
        public Actions action { get; private set; }
        private readonly ScenarioContext _scenarioContext;
        public Hooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
            this.container = container;
            config = InitConfiguration();
            container.RegisterInstanceAs<IConfiguration>(config);
            _scenarioContext = scenarioContext;
        }

        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(@"appsettings.json")
                .Build();
            return config;
        }

        public void SetupChromeDriver()
        {
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            container.RegisterInstanceAs<IWebDriver>(driver);
        }

        public void SetupFirefoxDriver()
        {
            var firefoxOptions = new FirefoxOptions();
            //firefoxOptions.AddArguments("headless");
            driver = new FirefoxDriver(firefoxOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [BeforeScenario]
        public void BeforeScenario(FeatureContext featureContext, ScenarioContext context)
        {
            _scenarioContext.TryGetValue("Browser", out var browser);

            switch (browser)
            {
                case "Chrome":
                    SetupChromeDriver();
                    break;
                case "Firefox":
                    SetupFirefoxDriver();
                    break;
                default:
                    SetupChromeDriver();
                    break;
            }
            action = new Actions(driver);
            container.RegisterInstanceAs<Actions>(action);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
