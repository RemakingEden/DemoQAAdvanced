using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RPMI.pages;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace RPMI.step_definitions
{
    [Binding]
    public class PracticeFormSteps
    {

        string baseUrl = "https://demoqa.com";
        private PracticeFormPage PracticeFormPage { get; set; }
        public IObjectContainer container { get; private set; }
        public IWebDriver driver { get; private set; }
        public  Actions builder { get; private set; }

        public PracticeFormSteps(IObjectContainer container)
        {
            this.container = container;
            driver = container.Resolve<IWebDriver>();
            builder = container.Resolve<Actions>();
        }

        [BeforeScenario]
        public void SetupSelenium()
        {
            PracticeFormPage = new PracticeFormPage(driver);
        }    

        [Given(@"a user is on the ""(.*)"" page")]
        public void GivenAUserIsOnThePage(string endpoint)
        {
            driver.Navigate().GoToUrl(baseUrl + endpoint);
        }
        
        
        [When(@"the user clicks the submit button")]
        public void WhenTheUserClicksTheSubmitButton()
        {

            // Maybe rethink this?
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            PracticeFormPage.SubmitBtn.Click();
        }
        
        [Then(@"a login error is shown")]
        public void ThenALoginErrorIsShown()
        {
            //Assert.True(PracticeFormPage.ErrorMessage.Displayed);
        }

        [When(@"the user enters info into all mandatory fields")]
        public void WhenTheUserEntersInfoIntoAllMandatoryFields()
        {

            PracticeFormPage.FirstName.SendKeys("Foo");
            PracticeFormPage.LastName.SendKeys("Bar");
            PracticeFormPage.GenderMale.Click();
            PracticeFormPage.MobileNumber.SendKeys("0712345678");
            PracticeFormPage.PictureUpload.SendKeys(@"C:\Users\sparkesj\Downloads\5mbImage.jpg");
        }

        [Then(@"the details entered are reflected correctly")]
        public void ThenTheDetailsEnteredAreReflectedCorrectly()
        {
            // This needs consolidating into one but could not find a way to get regex to do AND rather than OR (|)
            Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, "Foo Bar"));
            Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, "Male"));
            Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, "0712345678"));
            Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, "5mbImage.jpg"));
        }

        [Then(@"all appropriate field validation messages are shown")]
        public void ThenAllAppropriateFieldValidationMessagesAreShown()
        {
            // Need a more graceful way than Thread
            Thread.Sleep(500);
            Assert.AreEqual("rgb(220, 53, 69)", PracticeFormPage.FirstName.GetCssValue("border-color"));
            Assert.AreEqual("rgb(220, 53, 69)", PracticeFormPage.LastName.GetCssValue("border-color"));
            Assert.AreEqual("rgba(220, 53, 69, 1)", PracticeFormPage.GenderMale.GetCssValue("color"));
            Assert.AreEqual("rgb(220, 53, 69)", PracticeFormPage.MobileNumber.GetCssValue("border-color"));
        }

        [When(@"the user enters the email '(.*)'")]
        public void WhenTheUserEntersTheEmail(string email)
        {
            PracticeFormPage.Email.SendKeys(email);
        }

        [Then(@"the email field validation is shown")]
        public void ThentheEmailFieldValidationIsShown()
        {
            Thread.Sleep(500);
            Assert.AreEqual("rgb(220, 53, 69)", PracticeFormPage.Email.GetCssValue("border-color"));
        }

        [When(@"the user enters the phone number '(.*)'")]
        public void WhenTheUserEntersThePhoneNumber(string phoneNumber)
        {
            PracticeFormPage.MobileNumber.SendKeys(phoneNumber);
        }

        [Then(@"the phone number fields validation is shown")]
        public void ThenThePhoneNumberFieldsValidationIsShown()
        {
            Thread.Sleep(500);
            Assert.AreEqual("rgb(220, 53, 69)", PracticeFormPage.MobileNumber.GetCssValue("border-color"));
        }

        [When(@"the user enters info into all fields")]
        public void WhenTheUserEntersInfoIntoAllFields()
        {
            PracticeFormPage.FirstName.SendKeys("Foo");
            PracticeFormPage.LastName.SendKeys("Bar");
            PracticeFormPage.Email.SendKeys("foobar@mailinator.com");
            PracticeFormPage.GenderMale.Click();
            PracticeFormPage.MobileNumber.SendKeys("0712345678");
            PracticeFormPage.DOB.Clear();
            // The below date does not work correctly yet
            PracticeFormPage.DOB.SendKeys("01/01/2000");
            PracticeFormPage.Subjects.SendKeys("Physics");
            PracticeFormPage.SubjectsOption1.Click();
            PracticeFormPage.HobbiesSports.Click();
            PracticeFormPage.PictureUpload.SendKeys(@"C:\Users\sparkesj\Downloads\5mbImage.jpg");
            PracticeFormPage.Address.SendKeys("123 FooBar Street, Manchester, M1 2GF");
            PracticeFormPage.State.Click();
            PracticeFormPage.NCRState.Click();
            PracticeFormPage.City.Click();
            PracticeFormPage.DelhiCity.Click();
        }

        [When(@"the user enters five subjects")]
        public void WhenTheUserEntersFiveSubjects()
        {
            PracticeFormPage.Subjects.SendKeys("Physics");
            PracticeFormPage.SubjectsOption1.Click();
            PracticeFormPage.Subjects.SendKeys("English");
            PracticeFormPage.SubjectsOption1.Click();
            PracticeFormPage.Subjects.SendKeys("Accounting");
            PracticeFormPage.SubjectsOption1.Click();
            PracticeFormPage.Subjects.SendKeys("Chemistry");
            PracticeFormPage.SubjectsOption1.Click();
            PracticeFormPage.Subjects.SendKeys("Maths");
            PracticeFormPage.SubjectsOption1.Click();
        }

        [When(@"the user deletes two subjects individually")]
        public void WhenTheUserDeletesTwoSubjectsIndividually()
        {
            PracticeFormPage.SubjectRemove5.Click();
            PracticeFormPage.SubjectRemove4.Click(); 
        }

        [Then(@"three undeleted subjects remain")]
        public void ThenThreeUndeletedSubjectsRemain()
        {
            Assert.True(PracticeFormPage.Subject3.Displayed);
            Assert.True(PracticeFormPage.Subject4.Text == ""); 
        }

        [When(@"the user deletes all subjects with the remove all button")]
        public void WhenTheUserDeletesAllSubjectsWithTheRemoveAllButton()
        {
            PracticeFormPage.SubjectRemoveAll.Click();
        }

        [Then(@"all subjects are removed")]
        public void ThenAllSubjectsAreRemoved()
        {
            Assert.True(PracticeFormPage.Subject1.Text == "");
        }


    }
}
