using EAAutoFramework.Base;
using EAEmployeeTest.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace EAEmployeeTest.Steps
{
    [Binding]
    public class LoginSteps : BaseStep
    {
        //In Binding classes we need to set a ParallelConfig variable
        private ParallelConfig _parallelConfig;
        public LoginSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        [When(@"I enter UserName and Password")]
        public void WhenIEnterUserNameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            new LoginPage(_parallelConfig).Login(data.UserName, data.Password);
        }

        [Then(@"I should see the username with hello")]
        public void ThenIShouldSeeTheUsernameWithHello()
        {
            if (new HomePage(_parallelConfig).GetLoggedInUser().Contains("admin"))
                System.Console.WriteLine("Sucess login");
            else
                System.Console.WriteLine("Unsucessful login");
        }


        [Then(@"I click logout")]
        public void ThenIClickLogout()
        {
            _parallelConfig.CurrentPage.As<HomePage>().ClickLogOff();
        }



    }
}
