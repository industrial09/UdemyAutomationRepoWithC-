using EAAutoFramework.Base;
using TechTalk.SpecFlow;
using EAAutoFramework.Helpers;
using EAAutoFramework.Config;

namespace EAEmployeeTest.Hooks
{

    [Binding]
    public class HookInitialize : TestInitializeHook
    {

        [AfterStep]
        public void AfterEachStep()
        {
            var stepName = ScenarioContext.Current.StepContext.StepInfo.Text;
            var featureName = FeatureContext.Current.FeatureInfo.Title;
            var scenarioName = ScenarioContext.Current.ScenarioInfo.Title;

            //if (ScenarioContext.Current.TestError != null)
            //    _client.WriteTestResult(featureName, scenarioName, stepName, ScenarioContext.Current.TestError.StackTrace, "FAILED");
            //else
            //    _client.WriteTestResult(featureName, scenarioName, stepName, "", "PASSED");
        }

        [BeforeTestRun]
        public static void TestInitalize()
        {
            InitializeSettings();
            Settings.ApplicationCon = Settings.ApplicationCon.DBConnect(Settings.AppConnectionString);
        }


        [AfterScenario]
        public void TestStop()
        {
            //DriverContext.Driver.Quit();
        }

    }
}
