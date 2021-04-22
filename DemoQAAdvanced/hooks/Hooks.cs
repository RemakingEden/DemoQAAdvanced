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
        private readonly ScenarioContext _scenarioContext;
        private readonly DriverHelper driverHelper;
        public Hooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
            this.container = container;
            config = ConfigurationSetup.InitConfiguration();
            container.RegisterInstanceAs(config);
            _scenarioContext = scenarioContext;
            driverHelper = new DriverHelper();
        }

        [BeforeScenario]
        public void BeforeScenario(FeatureContext featureContext, ScenarioContext context)
        {
            driver = driverHelper.DriverSetup(_scenarioContext);
            container.RegisterInstanceAs(driver);
            var action = driverHelper.ActionSetup();
            container.RegisterInstanceAs(action);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
