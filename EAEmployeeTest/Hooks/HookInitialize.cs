using EAAutoFramework.Base;
using TechTalk.SpecFlow;
using EAAutoFramework.Helpers;
using EAAutoFramework.Config;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using System.Reflection;

namespace EAEmployeeTest.Hooks
{

    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        //Create html report
        static ExtentHtmlReporter extentHtmlReporter;
        static ExtentReports extentReports;
        ExtentTest featureName;
        ExtentTest scenario;

        private ParallelConfig _parallelConfig;
        private FeatureContext _featureContext;
        private ScenarioContext _scenarioContext;

        public HookInitialize(ParallelConfig parallelConfig, FeatureContext featureContext, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void TestInitalize()
        {
            extentHtmlReporter = new ExtentHtmlReporter(@"C:\Users\Christian Bautista\Downloads\EATestProject_UntilPOMRefactor (1)\EAEmployeeTest\ExtentReport.html");
            extentHtmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            //Attach report to ExtentReport object
            extentReports = new ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);
        }

        [AfterScenario]
        public void TestStop()
        {
            _parallelConfig.Driver.Quit();
        }

        [AfterStep]
        public void afterStep() {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
            }
        }

        [BeforeScenario]
        public void beforeScenario() {
            InitializeSettings();
            Settings.ApplicationCon = Settings.ApplicationCon.DBConnect(Settings.AppConnectionString);
            featureName = extentReports.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterTestRun]
        public static void flushReport() {
            extentReports.Flush();
        }

    }
}
