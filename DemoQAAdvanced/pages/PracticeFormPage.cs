using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RPMI.pages
{
    public class PracticeFormPage
    {
        private readonly IWebDriver driver;
        public PracticeFormPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        // Text fields
        [FindsBy(How = How.Id, Using = "firstName")]
        public IWebElement FirstName { get; set; }
        [FindsBy(How = How.Id, Using = "lastName")]
        public IWebElement LastName { get; set; }
        [FindsBy(How = How.Id, Using = "userEmail")]
        public IWebElement Email { get; set; }
        [FindsBy(How = How.Id, Using = "userNumber")]
        public IWebElement MobileNumber { get; set; }
        [FindsBy(How = How.Id, Using = "dateOfBirthInput")]
        public IWebElement DOB { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='subjectsInput']")]
        public IWebElement Subjects { get; set; }
        [FindsBy(How = How.Id, Using = "react-select-2-option-0")]
        public IWebElement SubjectsOption1 { get; set; }
        [FindsBy(How = How.Id, Using = "currentAddress")]
        public IWebElement Address { get; set; }
        [FindsBy(How = How.Id, Using = "state")]
        public IWebElement State { get; set; }
        [FindsBy(How = How.Id, Using = "react-select-3-option-0")]
        public IWebElement NCRState { get; set; }
        [FindsBy(How = How.Id, Using = "city")]
        public IWebElement City { get; set; }
        [FindsBy(How = How.Id, Using = "react-select-4-option-0")]
        public IWebElement DelhiCity { get; set; }

        // Radio buttons
        [FindsBy(How = How.XPath, Using = "//*[@id='genterWrapper']/div[2]/div[1]/label")]
        public IWebElement GenderMale { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='genterWrapper']/div[2]/div[2]/label")]
        public IWebElement GenderFemale { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='genterWrapper']/div[2]/div[3]/label")]
        public IWebElement GenderOther { get; set; }
        [FindsBy(How = How.XPath, Using = @"//*[@id='hobbiesWrapper']/div[2]/div[1]/label")]
        public IWebElement HobbiesSports { get; set; }

        // Picture upload
        [FindsBy(How = How.Id, Using = "uploadPicture")]
        public IWebElement PictureUpload { get; set; }

        // Buttons
        [FindsBy(How = How.Id, Using = "submit")]
        public IWebElement SubmitBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='subjectsContainer']/div/div[1]/div[4]/div[2]")]
        public IWebElement SubjectRemove4 { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='subjectsContainer']/div/div[1]/div[5]/div[2]")]
        public IWebElement SubjectRemove5 { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='subjectsContainer']/div/div[2]")]
        public IWebElement SubjectRemoveAll { get; set; }

        // Text
        [FindsBy(How = How.XPath, Using = "//*[@id='subjectsContainer']/div/div[1]/div[1]")]
        public IWebElement Subject1 { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='subjectsContainer']/div/div[1]/div[3]")]
        public IWebElement Subject3 { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='subjectsContainer']/div/div[1]/div[4]")]
        public IWebElement Subject4 { get; set; }

        // Reflected details
        [FindsBy(How = How.ClassName, Using = "modal-body")]
        public IWebElement ReflectedForm { get; set; }

        public void ClickSubmitBtn()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            this.SubmitBtn.Click();
        }

        public void InputSubject(string subject)
        {
            this.Subjects.SendKeys(subject);
            this.SubjectsOption1.Click();
        }
    }
}