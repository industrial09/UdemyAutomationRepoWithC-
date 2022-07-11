using EAAutoFramework.Base;
using EAEmployeeTest.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace EAEmployeeTest.Steps
{
    [Binding]
    class CreateEmployeeStep : BaseStep
    {
        private ParallelConfig _parallelConfig;
        public CreateEmployeeStep(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        [Then(@"I enter following details")]
        public void ThenIEnterFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            new CreateEmployeePage(_parallelConfig).CreateEmployee(data.Name,
                data.Salary.ToString(), data.DurationWorked.ToString(), data.Grade.ToString(), data.Email);

        }

        [Then(@"I create and delete user")]
        public void ThenICreateAndDeleteUser()
        {
            //ScenarioContext.Current.Pending();
        }


    }
}
