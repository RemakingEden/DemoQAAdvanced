using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace DemoQAAdvanced.pages
{
    public class ToolTipsPage
    {
        private readonly IWebDriver driver;
        public IObjectContainer container { get; private set; }

        public Actions action { get; private set; }
        public ToolTipsPage (IWebDriver driver, IObjectContainer container)
        {
            this.container = container;
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            action = container.Resolve<Actions>();

        }

        // Buttons
        [FindsBy(How = How.Id, Using = "toolTipButton")]
        public IWebElement ToolTipButton { get; set; }
        [FindsBy(How = How.Id, Using = "toolTipTextField")]
        public IWebElement ToolTipTextField { get; set; }

        // Hover Messages
        [FindsBy(How = How.ClassName, Using = "tooltip-inner")]
        public IWebElement ToolTipHoverMessage { get; set; }

        public void HoverElement(IWebElement element)
        {
            action
                .MoveToElement(element)
                .Build()
                .Perform();
        }

    }
}