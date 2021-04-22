using BoDi;
using DemoQAAdvanced.Pages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DemoQAAdvanced.StepDefinitions
{
    [Binding]
    public class ToolTipsSteps
    {

        private ToolTipsPage ToolTipsPage { get; set; }
        public IObjectContainer container { get; private set; }
        public IWebDriver driver { get; private set; }
        public IConfiguration config { get; private set; }

        public ToolTipsSteps(IObjectContainer container)
        {
            this.container = container;
            driver = container.Resolve<IWebDriver>();
            config = container.Resolve<IConfiguration>();
            ToolTipsPage = new ToolTipsPage(driver, container);
        }

        [When(@"the user hovers over the button")]
        public void WhenTheUserHoversOverTheButton()
        {
            ToolTipsPage.HoverElement(ToolTipsPage.ToolTipButton);
        }

        [When(@"the user hovers over the text field")]
        public void WhenTheUserHoversOverTheTextField()
        {
            ToolTipsPage.HoverElement(ToolTipsPage.ToolTipTextField);
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
