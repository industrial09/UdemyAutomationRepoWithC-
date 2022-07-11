# UdemyAutomationRepoWithCSharp_ParallelTestRun

IMPORTANT NOTES!!!!!!
For running in a Parallel mode our test scripts, we need:
1. To use the RemoteWebDriver class
2. Add under Test project -> Properties -> AssemblyInfo.cs following info
	[assembly: Parallelizable(ParallelScope.Fixtures)]
	this above info is imported from NUnit framework
	And we need it to run our test scripts in a PARALLEL MODE!!!
2. Make use of Selenium Grid, dowloading the Selenium server jar
3. We need to execute 1st commnad below in a cmd console and 2nd command below in another one!!!!!

1st command:
java -jar seleniumserver_Name.jar -role hub

2nd command:
java -jar selenium_serverName.jar -role webdriver -hub http://<ip_ofSeleniumHub>:4444/grid/register -port 5556

note: Seems like this only works for version 3 of Selenium 3.11.0 selenium-server works fine
