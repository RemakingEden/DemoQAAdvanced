using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DemoQAAdvanced.StepDefinitions
{
    [Binding]
    public class UniversalSteps
    {

        public IObjectContainer container { get; private set; }
        public IWebDriver driver { get; private set; }
        public IConfiguration config { get; private set; }

        public UniversalSteps(IObjectContainer container)
        {
            this.container = container;
            driver = container.Resolve<IWebDriver>();
            config = container.Resolve<IConfiguration>();
        }

        [Given(@"a user is on the ""(.*)"" page")]
        public void GivenAUserIsOnThePage(string endpoint)
        {
            driver.Navigate().GoToUrl(config["BaseURL"] + endpoint);
        }

    }
}
