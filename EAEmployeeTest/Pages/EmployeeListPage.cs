using EAAutoFramework.Base;
using OpenQA.Selenium;

namespace EAEmployeeTest.Pages
{
    public class EmployeeListPage : BasePage
    {
        //We only need to set the constructor with Context Injection class (ParallelConfig in this case)
        //to initiliaze the Driver variable
        public EmployeeListPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }

        IWebElement txtSearch => _parallelConfig.Driver.FindElement(By.Name("searchTerm"));

        IWebElement lnkCreateNew => _parallelConfig.Driver.FindElement(By.LinkText("Create New"));

        IWebElement tblEmployeeList => _parallelConfig.Driver.FindElement(By.ClassName("table"));

        IWebElement lnkLogoff => _parallelConfig.Driver.FindElement(By.LinkText("Log off"));

        public CreateEmployeePage ClickCreateNew()
        {
            lnkCreateNew.Click();
            return new CreateEmployeePage(_parallelConfig);
        }

        public IWebElement GetEmployeeList() => tblEmployeeList;

        internal void ClickLogoff() => lnkLogoff.Click();
    }
}
