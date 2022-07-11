using EAAutoFramework.Base;
using EAAutoFramework.Extensions;
using OpenQA.Selenium;

namespace EAEmployeeTest.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }

        IWebElement lnkLogin => _parallelConfig.Driver.FindElement(By.LinkText("Login"));

        IWebElement lnkEmployeeList => _parallelConfig.Driver.FindElement(By.LinkText("Employee List"));

        IWebElement lnkLoggedInUser => _parallelConfig.Driver.FindElement(By.XPath("//a[@title='Manage']"));

        IWebElement lnkLogoff => _parallelConfig.Driver.FindElement(By.LinkText("Log off"));


        internal void CheckIfLoginExist() => lnkLogin.AssertElementPresent();


        internal LoginPage ClickLogin()
        {
            lnkLogin.Click();
            return new LoginPage(_parallelConfig);
        }

        internal string GetLoggedInUser() => lnkLoggedInUser.GetLinkText();

        public EmployeeListPage ClickEmployeeList()
        {
            lnkEmployeeList.Click();
            return new EmployeeListPage(_parallelConfig);
        }

        internal LoginPage ClickLogOff()
        {
            lnkLogoff.Click();
            return new LoginPage(_parallelConfig);
        }
    }
}
