using BoDi;
using OpenQA.Selenium;
using RPMI.pages;
using TechTalk.SpecFlow;
using NUnit.Framework;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using System;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace RPMI.step_definitions
{
    [Binding]
    public class LoginSteps
    {

        string baseUrl = "https://demoqa.com/";
        private LoginPage LoginPage { get; set; }
        public IObjectContainer container { get; private set; }
        public IWebDriver driver { get; private set; }
        public LoginSteps(IObjectContainer container)
        {
            this.container = container;
            driver = container.Resolve<IWebDriver>();
        }

        [BeforeScenario]
        public void SetupSelenium()
        {
            LoginPage = new LoginPage(driver);
        }    

        [Given(@"a user is on the ""(.*)"" page")]
        public void GivenAUserIsOnThePage(string endpoint)
        {
            driver.Navigate().GoToUrl(baseUrl + endpoint);
        }
        
        [When(@"the user logs in as username '(.*)'")]
        public void WhenTheUserLogsInAsUsername(string username)
        {
            //LoginPage.Username.SendKeys(username);
        }
        
        [When(@"the user logs in with password '(.*)'")]
        public void WhenTheUserLogsInWithPassword(string password)
        {
            //LoginPage.Password.SendKeys(password);
        }
        
        [When(@"the user clicks the submit button")]
        public void WhenTheUserClicksTheSubmitButton()
        {
            //LoginPage.LoginBtn.Click();
        }
        
        [Then(@"a login error is shown")]
        public void ThenALoginErrorIsShown()
        {
            //Assert.True(LoginPage.ErrorMessage.Displayed);
        }

    }
}
