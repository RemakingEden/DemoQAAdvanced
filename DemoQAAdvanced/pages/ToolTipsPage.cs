using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DemoQAAdvanced.pages
{
    public class ToolTipsPage
    {
        private readonly IWebDriver driver;
        public ToolTipsPage (IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);

        }

        // Buttons
        [FindsBy(How = How.Id, Using = "toolTipButton")]
        public IWebElement ToolTipButton { get; set; }
        [FindsBy(How = How.Id, Using = "toolTipTextField")]
        public IWebElement ToolTipTextField { get; set; }

        // Hover Messages
        [FindsBy(How = How.ClassName, Using = "tooltip-inner")]
        public IWebElement ToolTipHoverMessage { get; set; }

    }
}