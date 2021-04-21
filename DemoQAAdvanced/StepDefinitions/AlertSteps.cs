using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using DemoQAAdvanced.pages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace DemoQAAdvanced.step_definitions
{

    [Binding]
    public class AlertSteps
    {
        private AlertPage AlertPage { get; set; }
        public IObjectContainer container { get; private set; }
        public IWebDriver driver { get; private set; }
        public IConfiguration config { get; private set; }

        public AlertSteps(IObjectContainer container)
        {
            this.container = container;
            driver = container.Resolve<IWebDriver>();
            config = container.Resolve<IConfiguration>();
            AlertPage = new AlertPage(driver);
        }

        [When(@"the user clicks on the second button")]
        public void WhenTheUserClicksOnTheSecondButton()
        {
            AlertPage.TimerAlertButton.Click();
        }
        
        [When(@"waits for five seconds")]
        public void WhenWaitsForFiveSeconds()
        {
            Thread.Sleep(5250);
        }
        
        [Then(@"an alert is shown")]
        public void ThenAnAlertIsShown()
        {
            Assert.AreEqual("This alert appeared after 5 seconds", driver.SwitchTo().Alert().Text);
        }

        [When(@"dismisses the alert")]
        public void WhenDismissesTheAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        [Then(@"the alert is no longer shown")]
        public void ThenTheAlertIsNoLongerShown()
        {
            var exception = Assert.Throws<NoAlertPresentException>(() => driver.SwitchTo().Alert().Accept());
            Assert.IsTrue(Regex.IsMatch(exception.Message, "no such alert"));
        }

    }
}
