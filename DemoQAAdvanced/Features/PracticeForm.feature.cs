// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.7.0.0
//      SpecFlow Generator Version:3.7.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
// Generation customised by SpecFlow.Contrib.Variants
namespace DemoQAAdvanced.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.7.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Practice Form")]
    [NUnit.Framework.CategoryAttribute("Browser:Chrome")]
    public partial class PracticeFormFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PracticeForm.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Practice Form", "  As a user\r\n  I want to be able to complete a form, so that I am able to send de" +
                    "tails to the site", ProgrammingLanguage.CSharp, new string[] {
                        "Browser:Chrome"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("All mandatory fields filled allows form to be submitted: Chrome")]
        [NUnit.Framework.CategoryAttribute("Browser:Chrome")]
        public virtual void AllMandatoryFieldsFilledAllowsFormToBeSubmitted_Chrome()
        {
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("All mandatory fields filled allows form to be submitted", null, ((string[])(null)), argumentsOfScenario);
            this.ScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.Add("Browser", "Chrome");
            this.ScenarioStart();
            testRunner.Given("a user is on the \"/automation-practice-form\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
            testRunner.When("the user enters info into all mandatory fields", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
            testRunner.And("the user clicks the submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
            testRunner.Then("the details entered are reflected correctly", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("All mandatory fields not filled shows validation error: Chrome")]
        [NUnit.Framework.CategoryAttribute("Browser:Chrome")]
        public virtual void AllMandatoryFieldsNotFilledShowsValidationError_Chrome()
        {
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("All mandatory fields not filled shows validation error", null, ((string[])(null)), argumentsOfScenario);
            this.ScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.Add("Browser", "Chrome");
            this.ScenarioStart();
            testRunner.Given("a user is on the \"/automation-practice-form\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
            testRunner.When("the user clicks the submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
            testRunner.Then("all appropriate field validation messages are shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("email wrong format shows validation error: Chrome")]
        [NUnit.Framework.CategoryAttribute("Browser:Chrome")]
        public virtual void EmailWrongFormatShowsValidationError_Chrome()
        {
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("email wrong format shows validation error", null, ((string[])(null)), argumentsOfScenario);
            this.ScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.Add("Browser", "Chrome");
            this.ScenarioStart();
            testRunner.Given("a user is on the \"/automation-practice-form\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
            testRunner.When("the user enters the email \'WrongFormat\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
            testRunner.And("the user clicks the submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
            testRunner.Then("the email field validation is shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Letters in phone number shows validation error: Chrome")]
        [NUnit.Framework.CategoryAttribute("Browser:Chrome")]
        public virtual void LettersInPhoneNumberShowsValidationError_Chrome()
        {
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Letters in phone number shows validation error", null, ((string[])(null)), argumentsOfScenario);
            this.ScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.Add("Browser", "Chrome");
            this.ScenarioStart();
            testRunner.Given("a user is on the \"/automation-practice-form\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
            testRunner.When("the user enters the phone number \'WrongFormat\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
            testRunner.And("the user clicks the submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
            testRunner.Then("the phone number fields validation is shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("All fields filled allows form to be submitted: Chrome")]
        [NUnit.Framework.CategoryAttribute("Browser:Chrome")]
        public virtual void AllFieldsFilledAllowsFormToBeSubmitted_Chrome()
        {
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("All fields filled allows form to be submitted", null, ((string[])(null)), argumentsOfScenario);
            this.ScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.Add("Browser", "Chrome");
            this.ScenarioStart();
            testRunner.Given("a user is on the \"/automation-practice-form\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
            testRunner.When("the user enters info into all fields", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
            testRunner.And("the user clicks the submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
            testRunner.Then("the details entered are reflected correctly", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Can remove subjects individually: Chrome")]
        [NUnit.Framework.CategoryAttribute("Browser:Chrome")]
        public virtual void CanRemoveSubjectsIndividually_Chrome()
        {
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Can remove subjects individually", null, ((string[])(null)), argumentsOfScenario);
            this.ScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.Add("Browser", "Chrome");
            this.ScenarioStart();
            testRunner.Given("a user is on the \"/automation-practice-form\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
            testRunner.When("the user enters five subjects", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
            testRunner.And("the user deletes two subjects individually", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
            testRunner.Then("three undeleted subjects remain", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Can remove all subjects: Chrome")]
        [NUnit.Framework.CategoryAttribute("Browser:Chrome")]
        public virtual void CanRemoveAllSubjects_Chrome()
        {
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Can remove all subjects", null, ((string[])(null)), argumentsOfScenario);
            this.ScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.Add("Browser", "Chrome");
            this.ScenarioStart();
            testRunner.Given("a user is on the \"/automation-practice-form\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
            testRunner.When("the user enters five subjects", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
            testRunner.And("the user deletes all subjects with the remove all button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
            testRunner.Then("all subjects are removed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
