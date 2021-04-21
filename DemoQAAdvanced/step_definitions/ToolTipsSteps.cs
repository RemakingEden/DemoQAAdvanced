using BoDi;
using DemoQAAdvanced.pages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;

namespace DemoQAAdvanced.step_definitions
{
    [Binding]
    public class ToolTipsSteps
    {

        private ToolTipsPage ToolTipsPage { get; set; }
        public IObjectContainer container { get; private set; }
        public IWebDriver driver { get; private set; }
        public IConfiguration config { get; private set; }
        public Actions actions { get; private set; }

        public ToolTipsSteps(IObjectContainer container)
        {
            this.container = container;
            driver = container.Resolve<IWebDriver>();
            config = container.Resolve<IConfiguration>();
            ToolTipsPage = new ToolTipsPage(driver);
            Actions actions = new Actions(driver);
            this.actions = actions;
        }

        [When(@"the user hovers over the button")]
        public void WhenTheUserHoversOverTheButton()
        {
            actions.MoveToElement(ToolTipsPage.ToolTipButton);
            actions.Build();
            actions.Perform();
        }
        
        [When(@"the user hovers over the text field")]
        public void WhenTheUserHoversOverTheTextField()
        {
            actions.MoveToElement(ToolTipsPage.ToolTipTextField);
            actions.Build();
            actions.Perform();
        }

        [Then(@"a button hover message is shown")]
        public void ThenAButtonHoverMessageIsShown()
        {
            Assert.AreEqual("You hovered over the Button", ToolTipsPage.ToolTipHoverMessage.Text);
        }

        [Then(@"a text hover message is shown")]
        public void ThenATextHoverMessageIsShown()
        {
            Assert.AreEqual("You hovered over the text field", ToolTipsPage.ToolTipHoverMessage.Text);
        }


    }
}
