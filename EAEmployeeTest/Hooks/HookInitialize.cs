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
        static ExtentTest featureName;
        ExtentTest scenario;

        [BeforeTestRun]
        public static void TestInitalize()
        {
            extentHtmlReporter = new ExtentHtmlReporter(@"C:\Users\Christian Bautista\Downloads\EATestProject_UntilPOMRefactor (1)\EAEmployeeTest\ExtentReport.html");
            extentHtmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            //Attach report to ExtentReport object
            extentReports = new ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);
            InitializeSettings();
            Settings.ApplicationCon = Settings.ApplicationCon.DBConnect(Settings.AppConnectionString);
        }
        [BeforeFeature]
        public static void beforeFeature() {
            featureName = extentReports.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterScenario]
        public void TestStop()
        {
            //DriverContext.Driver.Quit();
        }

        [AfterStep]
        public void afterStep() {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            /*PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(ScenarioContext.Current, null);*/

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given") scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When") scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then") scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And") scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null) {
                if (stepType == "Given") scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "When") scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "Then") scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "And") scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
            }
            //Pending Status
            /*if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given") scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When") scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then") scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "And") scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            }*/
        }

        [BeforeScenario]
        public void beforeScenario() {
            scenario = extentReports.CreateTest<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterTestRun]
        public static void flushReport() {
            extentReports.Flush();
        }

    }
}
