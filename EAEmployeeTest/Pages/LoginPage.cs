using EAAutoFramework.Base;
using OpenQA.Selenium;
using EAAutoFramework.Extensions;

namespace EAEmployeeTest.Pages
{
    class LoginPage : BasePage
    {
        IWebElement txtUserName => DriverContext.Driver.FindElement(By.Id("UserName"));

        IWebElement txtPassword => DriverContext.Driver.FindElement(By.Id("Password"));

        IWebElement btnLogin => DriverContext.Driver.FindElement(By.CssSelector("input.btn"));


        public void Login(string userName, string password)
        {
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
        }


        public HomePage ClickLoginButton()
        {
            btnLogin.Submit();
            return GetInstance<HomePage>();
        }


        internal void CheckIfLoginExist()
        {
            txtUserName.AssertElementPresent();
        }
    }
}
