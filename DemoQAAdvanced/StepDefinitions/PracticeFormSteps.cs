using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using DemoQAAdvanced.pages;
using DemoQAAdvanced.POCO;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
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
        private readonly ScenarioContext _scenarioContext;

        public PracticeFormSteps(IObjectContainer container, ScenarioContext scenarioContext)
        {
            this.container = container;
            driver = container.Resolve<IWebDriver>();
            config = container.Resolve<IConfiguration>();
            PracticeFormPage = new PracticeFormPage(driver);
            _scenarioContext = scenarioContext;
        }
        
        [When(@"the user clicks the submit button")]
        public void WhenTheUserClicksTheSubmitButton()
        {
            PracticeFormPage.ClickSubmitBtn();
        }

        [When(@"the user enters info into all mandatory fields")]
        public void WhenTheUserEntersInfoIntoAllMandatoryFields()
        {
            _scenarioContext["Type"] = "Mandatory";
            PracticeFormPage.FirstName.SendKeys(PracticeFormData.FirstName);
            PracticeFormPage.LastName.SendKeys(PracticeFormData.LastName);
            PracticeFormPage.Email.SendKeys(PracticeFormData.Email);
            PracticeFormPage.GenderSelection(PracticeFormData.Gender);
            PracticeFormPage.MobileNumber.SendKeys(PracticeFormData.MobileNumber);
            PracticeFormPage.PictureUpload.SendKeys(PracticeFormData.PictureUpload);
        }

        [Then(@"the details entered are reflected correctly")]
        public void ThenTheDetailsEnteredAreReflectedCorrectly()
        {
            _scenarioContext.TryGetValue("Type", out var type);

            switch (type)
            {
                case "Mandatory":
                    Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, string.Format("{0} {1}", PracticeFormData.FirstName, PracticeFormData.LastName)));
                    Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, PracticeFormData.Gender));
                    Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, PracticeFormData.MobileNumber));
                    Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, Regex.Replace(PracticeFormData.PictureUpload, @".+\\", "")));
                    break;
                case "All":
                    Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, string.Format("{0} {1}", PracticeFormData.FirstName, PracticeFormData.LastName)));
                    Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, PracticeFormData.Email));
                    Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, PracticeFormData.Gender));
                    Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, PracticeFormData.MobileNumber));
                    //Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, PracticeFormData.DOB));
                    Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, PracticeFormData.Subject));
                    Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, PracticeFormData.Hobbies));
                    Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, Regex.Replace(PracticeFormData.PictureUpload, @".+\\", "")));
                    Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, PracticeFormData.Address));
                    Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, PracticeFormData.State));
                    Assert.IsTrue(Regex.IsMatch(PracticeFormPage.ReflectedForm.Text, PracticeFormData.City));
                    break;
            }


        }

        [Then(@"all appropriate field validation messages are shown")]
        public void ThenAllAppropriateFieldValidationMessagesAreShown()
        {
            PracticeFormPage.WaitForValidation(PracticeFormPage.FirstName);
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
            PracticeFormPage.WaitForValidation(PracticeFormPage.Email);
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
            PracticeFormPage.WaitForValidation(PracticeFormPage.MobileNumber);
            Assert.AreEqual("rgb(220, 53, 69)", PracticeFormPage.MobileNumber.GetCssValue("border-color"));
        }

        [When(@"the user enters info into all fields")]
        public void WhenTheUserEntersInfoIntoAllFields()
        {
            _scenarioContext["Type"] = "All";
            PracticeFormPage.FirstName.SendKeys(PracticeFormData.FirstName);
            PracticeFormPage.LastName.SendKeys(PracticeFormData.LastName);
            PracticeFormPage.Email.SendKeys(PracticeFormData.Email);
            PracticeFormPage.GenderSelection(PracticeFormData.Gender);
            PracticeFormPage.MobileNumber.SendKeys(PracticeFormData.MobileNumber);
            PracticeFormPage.DOBSelection(PracticeFormData.DOB);
            PracticeFormPage.InputSubject(PracticeFormData.Subject);
            PracticeFormPage.HobbySelection(PracticeFormData.Hobbies);
            PracticeFormPage.PictureUpload.SendKeys(PracticeFormData.PictureUpload);
            PracticeFormPage.Address.SendKeys(PracticeFormData.Address);
            PracticeFormPage.StateSelection(PracticeFormData.State);
            PracticeFormPage.CitySelection(PracticeFormData.City);
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
