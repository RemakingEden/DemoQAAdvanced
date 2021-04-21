using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DemoQAAdvanced.pages
{
    public class DroppablePage
    {
        private readonly IWebDriver driver;
        public DroppablePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);

        }

        [FindsBy(How = How.Id, Using = "draggable")]
        public IWebElement DraggableBox { get; set; }
        [FindsBy(How = How.Id, Using = "droppable")]
        public IWebElement DroppableBox { get; set; }
    }
}