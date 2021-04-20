using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;

namespace RPMI.hooks
{
    [Binding]
    public sealed class Hooks
    {
        private ExtentTest featureName;
        private ExtentTest scenario;
        private static ExtentReports extent;

        private readonly ScenarioContext _scenarioContext;
        public IObjectContainer container { get; private set; }
        private IWebDriver driver;
        public Hooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
            this.container = container;
            _scenarioContext = scenarioContext;
        }

        public IWebDriver SetupChromeDriver()
        {
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Actions builder = new Actions(driver);
            container.RegisterInstanceAs<IWebDriver>(driver);
            container.RegisterInstanceAs<Actions>(builder);
            return driver;
        }

        public IWebDriver SetupFirefoxDriver()
        {
            var firefoxOptions = new FirefoxOptions();
            //firefoxOptions.AddArguments("headless");
            driver = new FirefoxDriver(firefoxOptions);
            driver.Manage().Window.Maximize();
            container.RegisterInstanceAs<IWebDriver>(driver);
            return driver;
        }

        [BeforeTestRun]
        public static void InitialiseReport()
        {
            var htmlReporter = new ExtentHtmlReporter(@"C:\development\RPMI\RPMI\RPMI\output\ExtentReport.html");
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

        [BeforeScenario(Order = 0)]
        public void BeforeScenario(FeatureContext featureContext, ScenarioContext context)
        {
            var featureTest = featureContext.FeatureContainer.Resolve<ExtentTest>();
            scenario = featureTest.CreateNode<Scenario>(context.ScenarioInfo.Title);
            _scenarioContext.TryGetValue("Browser", out var browser);

            switch (browser)
            {
                case "Chrome":
                    driver = SetupChromeDriver();
                    break;
                case "Firefox":
                    driver = SetupFirefoxDriver();
                    break;
                default:
                    driver = SetupChromeDriver();
                    break;
            }
            _scenarioContext.ScenarioContainer.RegisterInstanceAs(driver);
            _scenarioContext.ScenarioContainer.RegisterInstanceAs(scenario);
        }


        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            var stepType = context.StepContext.StepInfo.StepDefinitionType.ToString();
            scenario = context.ScenarioContainer.Resolve<ExtentTest>();

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

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }

        [AfterTestRun]
        public static void FlushReport()
        {
            extent.Flush();
        }
    }
}
