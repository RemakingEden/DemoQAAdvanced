using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using DemoQAAdvanced.helper;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace DemoQAAdvanced.helper
{
    [Binding]
    public sealed class ExtentReporting
    {
        private static ExtentReports extent;

        private readonly ScenarioContext _scenarioContext;
        public IObjectContainer container { get; private set; }
        public IConfiguration config { get; private set; }

        public ExtentReporting(IObjectContainer container)
        {
            this.container = container;
            _scenarioContext = container.Resolve<ScenarioContext>();
        }

        [BeforeTestRun]
        public static void InitialiseReport()
        {
            var htmlReporter = new ExtentHtmlReporter(TestFolders.GetOutputFilePath("ExtentReport.html"));
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {

            var featureTest = extent.CreateTest<Feature>(context.FeatureInfo.Title);
            context.FeatureContainer.RegisterInstanceAs(featureTest);
        }

        [BeforeScenario]
        public void BeforeScenario(FeatureContext featureContext, ScenarioContext context)
        {
            var featureTest = featureContext.FeatureContainer.Resolve<ExtentTest>();
            var scenario = featureTest.CreateNode<Scenario>(context.ScenarioInfo.Title);
            _scenarioContext.ScenarioContainer.RegisterInstanceAs(scenario);
        }


        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            var stepType = context.StepContext.StepInfo.StepDefinitionType.ToString();
            var scenario = context.ScenarioContainer.Resolve<ExtentTest>();

            if (context.TestError == null)
            {
                switch (stepType)
                {
                    case "Given":
                        scenario.CreateNode<Given>(context.StepContext.StepInfo.Text);
                        break;
                    case "When":
                        scenario.CreateNode<When>(context.StepContext.StepInfo.Text);
                        break;
                    case "And":
                        scenario.CreateNode<And>(context.StepContext.StepInfo.Text);
                        break;
                    case "Then":
                        scenario.CreateNode<Then>(context.StepContext.StepInfo.Text);
                        break;

                }
            }
            else if (context.TestError != null)
            {
                switch (stepType)
                {
                    case "Given":
                        scenario.CreateNode<Given>(context.StepContext.StepInfo.Text).Fail(context.TestError.Message);
                        break;
                    case "When":
                        scenario.CreateNode<When>(context.StepContext.StepInfo.Text).Fail(context.TestError.Message);
                        break;
                    case "And":
                        scenario.CreateNode<And>(context.StepContext.StepInfo.Text).Fail(context.TestError.Message);
                        break;
                    case "Then":
                        scenario.CreateNode<Then>(context.StepContext.StepInfo.Text).Fail(context.TestError.Message);
                        break;

                }
            }
        }

        [AfterTestRun]
        public static void FlushReport()
        {
            extent.Flush();
        }
    }
}
