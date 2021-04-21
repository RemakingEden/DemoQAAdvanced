using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using DemoQAAdvanced.helper;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using DemoQAAdvanced.pages;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace DemoQAAdvanced.step_definitions
{
    [Binding]
    public class PracticeFormSteps
    {

        private PracticeFormPage PracticeFormPage { get; set; }
        public IObjectContainer container { get; private set; }
        public IWebDriver driver { get; private set; }
        public IConfiguration config { get; private set; }

        public PracticeFormSteps(IObjectContainer container)
        {
            this.container = container;
            driver = container.Resolve<IWebDriver>();
            config = container.Resolve<IConfiguration>();
            PracticeFormPage = new PracticeFormPage(driver);
        }
        
        [When(@"the user clicks the submit button")]
        public void WhenTheUserClicksTheSubmitButton()
        {
            PracticeFormPage.ClickSubmitBtn();
        }

        [When(@"the user enters info into all mandatory fields")]
        public void WhenTheUserEntersInfoIntoAllMandatoryFields()
        {

            PracticeFormPage.FirstName.SendKeys("Foo");
            PracticeFormPage.LastName.SendKeys("Bar");
            PracticeFormPage.GenderMale.Click();
            PracticeFormPage.MobileNumber.SendKeys("0712345678");
            PracticeFormPage.PictureUpload.SendKeys(TestFolders.GetInputFilePath(@"..\..\..\input\5mbImage.jpg"));
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
            PracticeFormPage.PictureUpload.SendKeys(TestFolders.GetInputFilePath(@"..\..\..\input\5mbImage.jpg"));
            PracticeFormPage.Address.SendKeys("123 FooBar Street, Manchester, M1 2GF");
            PracticeFormPage.State.Click();
            PracticeFormPage.NCRState.Click();
            PracticeFormPage.City.Click();
            PracticeFormPage.DelhiCity.Click();
        }

        [When(@"the user enters five subjects")]
        public void WhenTheUserEntersFiveSubjects()
        {
            PracticeFormPage.InputSubject("Physics");
            PracticeFormPage.InputSubject("English");
            PracticeFormPage.InputSubject("Accounting");
            PracticeFormPage.InputSubject("Chemistry");
            PracticeFormPage.InputSubject("Maths");
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
