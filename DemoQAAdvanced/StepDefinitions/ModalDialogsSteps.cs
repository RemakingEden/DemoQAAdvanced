using BoDi;
using DemoQAAdvanced.pages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;


namespace DemoQAAdvanced.StepDefinitions
{
    [Binding]
    public class ModalDialogsSteps
    {

        private ModalDialogsPage ModalDialogsPage { get; set; }
        public IObjectContainer container { get; private set; }
        public IWebDriver driver { get; private set; }
        public IConfiguration config { get; private set; }
        public Actions action { get; private set; }

        public ModalDialogsSteps(IObjectContainer container)
        {
            this.container = container;
            driver = container.Resolve<IWebDriver>();
            config = container.Resolve<IConfiguration>();
            action = container.Resolve<Actions>();
            ModalDialogsPage = new ModalDialogsPage(driver);
        }

        [When(@"the user clicks on the small modal button")]
        public void WhenTheUserClicksOnTheSmallModalButton()
        {
            ModalDialogsPage.SmallModalButton.Click();
        }
        
        [When(@"clicks close on the small modal box")]
        public void WhenClicksCloseOnTheSmallModalBox()
        {
            ModalDialogsPage.SmallModalClose.Click();
        }
        
        [Then(@"a small modal is shown")]
        public void ThenASmallModalIsShown()
        {
            Assert.AreEqual("Small Modal", ModalDialogsPage.SmallModalHeader.Text);
        }
        
        [Then(@"a small modal is no longer showing")]
        public void ThenASmallModalIsNoLongerShowing()
        {
            Thread.Sleep(500);
            var exception = Assert.Throws<NoSuchElementException>(() => ModalDialogsPage.SmallModalClose.Click());
            Assert.IsTrue(Regex.IsMatch(exception.Message, "Could not find element by: By.Id: closeSmallModal"));
        }
    }
}
