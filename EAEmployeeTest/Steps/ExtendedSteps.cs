using EAAutoFramework.Base;
using EAAutoFramework.Config;
using EAAutoFramework.Helpers;
using EAEmployeeTest.Pages;
using TechTalk.SpecFlow;

namespace EAEmployeeTest.Steps
{
    [Binding]
    internal class ExtendedSteps : BaseStep
    {
        private ParallelConfig _parallelConfig;
        public ExtendedSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        [Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApplication()
        {
            _parallelConfig.Driver.Navigate().GoToUrl(Settings.AUT);
            _parallelConfig.CurrentPage = new HomePage(_parallelConfig);
        }


        [Given(@"I Delete employee '(.*)' before I start running test")]
        public void GivenIDeleteEmployeeBeforeIStartRunningTest(string employeeName)
        {
            string query = "delete from Employees where Name = '" + employeeName + "'";
            Settings.ApplicationCon.ExecuteQuery(query);
        }

        [Given(@"I see application opened")]
        public void GivenISeeApplicationOpened()
        {
            _parallelConfig.CurrentPage.As<HomePage>().CheckIfLoginExist();
        }

        [Then(@"I click (.*) link")]
        public void ThenIClickLink(string linkName)
        {
            if (linkName == "login")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickLogin();
            else if (linkName == "employeeList")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickEmployeeList();
        }

        [Then(@"I click (.*) button")]
        public void ThenIClickButton(string buttonName)
        {
            if (buttonName == "login")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<LoginPage>().ClickLoginButton();
            else if (buttonName == "createnew")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<EmployeeListPage>().ClickCreateNew();
            else if (buttonName == "create")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<CreateEmployeePage>().ClickCreateButton();
        }

        [Then(@"I click log off")]
        public void ThenIClickLogOff()
        {
            _parallelConfig.CurrentPage.As<EmployeeListPage>().ClickLogoff();
        }
    }
}
