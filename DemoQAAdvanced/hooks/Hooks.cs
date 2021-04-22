using BoDi;
using DemoQAAdvanced.Helpers;
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
        private readonly DriverSetup driverSetup;
        public Hooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
            this.container = container;
            config = ConfigurationSetup.InitConfiguration();
            container.RegisterInstanceAs(config);
            _scenarioContext = scenarioContext;
            driverSetup = new DriverSetup();
        }

        [BeforeScenario]
        public void BeforeScenario(FeatureContext featureContext, ScenarioContext context)
        {
            _scenarioContext.TryGetValue("Browser", out var browser);

            switch (browser)
            {
                case "Chrome":
                    driver = driverSetup.SetupChromeDriver();
                    break;
                case "Firefox":
                    driver = driverSetup.SetupFirefoxDriver();
                    break;
                default:
                    driver = driverSetup.SetupChromeDriver();
                    break;
            }
            container.RegisterInstanceAs(driver);
            action = new Actions(driver);
            container.RegisterInstanceAs(action);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
