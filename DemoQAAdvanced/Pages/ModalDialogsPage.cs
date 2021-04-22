using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DemoQAAdvanced.Pages
{
    public class ModalDialogsPage
    {
        private readonly IWebDriver driver;
        public ModalDialogsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);

        }

        // Buttons
        [FindsBy(How = How.Id, Using = "showSmallModal")]
        public IWebElement SmallModalButton { get; set; }
        [FindsBy(How = How.Id, Using = "closeSmallModal")]
        public IWebElement SmallModalClose { get; set; }

        // Modal
        [FindsBy(How = How.Id, Using = "example-modal-sizes-title-sm")]
        public IWebElement SmallModalHeader { get; set; }
    }
}