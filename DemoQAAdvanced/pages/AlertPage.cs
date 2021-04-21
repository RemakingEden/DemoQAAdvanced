using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DemoQAAdvanced.pages
{
    public class AlertPage
    {
        private readonly IWebDriver driver;
        public AlertPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);

        }

        // Buttons
        [FindsBy(How = How.Id, Using = "timerAlertButton")]
        public IWebElement TimerAlertButton { get; set; }
    }
}