using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EAEmployeeTest.Pages;
using EAAutoFramework.Helpers;
using EAEmployeeTest.Hooks;

namespace EAEmployeeTest
{
    [TestClass]
    public class UnitTest1 : HookInitialize
    {

        //[TestMethod]
        //public void TestMethod1()
        //{
        //    string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";
        //    ExcelHelpers.PopulateInCollection(fileName);
        //    //LoginPage
        //    CurrentPage = GetInstance<LoginPage>();
        //    CurrentPage.As<LoginPage>().ClickLoginLink();
        //    CurrentPage.As<LoginPage>().CheckIfLoginExist();
        //    CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1, "UserName"), ExcelHelpers.ReadData(1, "Password"));
        //    //EmployeePage
        //    CurrentPage = CurrentPage.As<LoginPage>().ClickEmployeeList();
        //    CurrentPage.As<EmployeePage>().ClickCreateNew();
        //}

        //[TestMethod]
        //public void TableOperation()
        //{
        //    string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";
        //    ExcelHelpers.PopulateInCollection(fileName);
        //    CurrentPage = GetInstance<LoginPage>();
        //    CurrentPage.As<LoginPage>().ClickLoginLink();
        //    CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1, "UserName"), ExcelHelpers.ReadData(1, "Password"));
        //    //EmployeePage
        //    CurrentPage = CurrentPage.As<LoginPage>().ClickEmployeeList();

        //    var table = CurrentPage.As<EmployeePage>().GetEmployeeList();

        //    HtmlTableHelper.ReadTable(table);
        //    HtmlTableHelper.PerformActionOnCell("5", "Name", "Ramesh", "Benefits");



        //}


    }
}
