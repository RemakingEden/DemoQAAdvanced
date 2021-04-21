using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using DemoQAAdvanced.helper;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using DemoQAAdvanced.pages;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace DemoQAAdvanced.step_definitions
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
