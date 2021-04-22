using BoDi;
using DemoQAAdvanced.Pages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace DemoQAAdvanced.StepDefinitions
{
    [Binding]
    public class DatePickerSteps
    {
        private DatePickerPage DatePickerPage { get; set; }
        public IObjectContainer container { get; private set; }
        public IWebDriver driver { get; private set; }
        public IConfiguration config { get; private set; }
        public Actions action { get; private set; }

        public DatePickerSteps(IObjectContainer container)
        {
            this.container = container;
            driver = container.Resolve<IWebDriver>();
            config = container.Resolve<IConfiguration>();
            action = container.Resolve<Actions>();
            DatePickerPage = new DatePickerPage(driver);
        }

        [When(@"the user enters a new date")]
        public void WhenTheUserEntersANewDate()
        {
            DatePickerPage.SelectDate(DatePickerPage.DateInOneMonth());
        }
        
        [Then(@"the same date the user entered is displayed")]
        public void ThenTheSameDateTheUserEnteredIsDisplayed()
        {
            Assert.AreEqual(DatePickerPage.DateInOneMonth(), DatePickerPage.SelectDateButton.GetAttribute("value"));
        }
    }
}
