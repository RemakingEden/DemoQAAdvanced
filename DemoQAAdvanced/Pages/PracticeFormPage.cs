using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace DemoQAAdvanced.Pages
{
    public class PracticeFormPage
    {
        private readonly IWebDriver driver;
        public PracticeFormPage(IWebDriver driver)
        {
            this. driver = driver;
            PageFactory.InitElements(driver, this);
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
        [FindsBy(How = How.Id, Using = "react-select-3-option-1")]
        public IWebElement UttarPradeshState { get; set; }
        [FindsBy(How = How.Id, Using = "react-select-3-option-2")]
        public IWebElement HaryanaState { get; set; }
        [FindsBy(How = How.Id, Using = "react-select-3-option-3")]
        public IWebElement RajasthanState { get; set; }
        [FindsBy(How = How.Id, Using = "city")]
        public IWebElement City { get; set; }
        [FindsBy(How = How.Id, Using = "react-select-4-option-0")]
        public IWebElement DelhiCity { get; set; }
        [FindsBy(How = How.Id, Using = "react-select-4-option-1")]
        public IWebElement GurgaonCity { get; set; }
        [FindsBy(How = How.Id, Using = "react-select-4-option-2")]
        public IWebElement NoidaCity { get; set; }

        // Radio buttons
        [FindsBy(How = How.XPath, Using = "//*[@id='genterWrapper']/div[2]/div[1]/label")]
        public IWebElement GenderMale { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='genterWrapper']/div[2]/div[2]/label")]
        public IWebElement GenderFemale { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='genterWrapper']/div[2]/div[3]/label")]
        public IWebElement GenderOther { get; set; }
        [FindsBy(How = How.XPath, Using = @"//*[@id='hobbiesWrapper']/div[2]/div[1]/label")]
        public IWebElement HobbiesSports { get; set; }
        [FindsBy(How = How.XPath, Using = @"//*[@id='hobbiesWrapper']/div[2]/div[2]/label")]
        public IWebElement HobbiesReading { get; set; }
        [FindsBy(How = How.XPath, Using = @"//*[@id='hobbiesWrapper']/div[2]/div[3]/label")]
        public IWebElement HobbiesMusic { get; set; }

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

        public void WaitForValidation(IWebElement field)
        {
            var x = 0;
            // Timeout is measured in 250 milliseconds
            var timeout = 40;
            while (x <= timeout)
            {

                if ("rgb(220, 53, 69)" == field.GetCssValue("border-color")){
                    break;
                }
                else
                {
                    Thread.Sleep(250);
                    x += 1;
                    continue;
                }
            } 
            if (x == timeout + 1){
                throw new Exception("Red validation highlight was not displayed");
            }
        }

        public void ClickSubmitBtn()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            SubmitBtn.Click();
        }

        public void InputSubject(string subject)
        {
            Subjects.SendKeys(subject);
            SubjectsOption1.Click();
        }

        public void GenderSelection(string gender)
        {
            if (gender == "Male"){
                GenderMale.Click();
            } 
            else if (gender == "Female")
            {
                GenderFemale.Click();
            }
            else if (gender == "Other")
            {
                GenderOther.Click();
            }
            else
            {
                throw new Exception("Gender must be Male/Female/Other");
            }
        }

        public void HobbySelection(string hobby)
        {
            if (hobby == "Sports")
            {
                HobbiesSports.Click();
            }
            else if (hobby == "Reading")
            {
                HobbiesReading.Click();
            }
            else if (hobby == "Music")
            {
                HobbiesMusic.Click();
            }
            else
            {
                throw new Exception("Hobby must be Sports/Reading/Music");
            }
        }

        public void StateSelection(string state)
        {
            State.Click();
            if (state == "NCR")
            {
                NCRState.Click();
            }
            else if (state == "Uttar Pradesh")
            {
                UttarPradeshState.Click();
            }
            else if (state == "Haryana")
            {
                HaryanaState.Click();
            }
            else if (state == "Rajasthan")
            {
                RajasthanState.Click();
            }
            else
            {
                throw new Exception("State must be NCR/Uttar Pradesh/Haryana/Rajasthan");
            }
        }

        public void CitySelection(string city)
        {
            City.Click();
            if (city == "Delhi")
            {
                DelhiCity.Click();
            }
            else if (city == "Gurgaon")
            {
                GurgaonCity.Click();
            }
            else if (city == "Noida")
            {
                NoidaCity.Click();
            }
            else
            {
                throw new Exception("City must be Delhi/Gurgaon/Noida");
            }
        }

        public void DOBSelection(string dob)
        {
            var x = 1;
            while (x < 11)
            {
                DOB.SendKeys(Keys.Backspace);
                x += 1;
            }
            Thread.Sleep(1000);
            DOB.SendKeys(dob);
            DOB.SendKeys(Keys.Enter);
        }
    }
}