using EAAutoFramework.Config;
using EAAutoFramework.Helpers;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.IO;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System;

namespace EAAutoFramework.Base
{
    public abstract class TestInitializeHook : Steps
    {
        private ParallelConfig _parallelConfig;
        public TestInitializeHook(ParallelConfig parallelConfig) { 
            this._parallelConfig = parallelConfig;
        }
        public void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //Set Log
            LogHelpers.CreateLogFile();

            //Open Browser
            OpenBrowser(Settings.BrowserType);

            LogHelpers.Write("Initialized framework");

        }

        private void OpenBrowser(BrowserType browserType = BrowserType.FireFox)
        {
            //DesiredCapabilites is a must when using Selenium Grid for Parallel execution
            DesiredCapabilities dc = new DesiredCapabilities();
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    //TODO
                    break;
                case BrowserType.FireFox:
                    dc.SetCapability(CapabilityType.BrowserName, "firefox");
                    dc.SetCapability(CapabilityType.PlatformName, Platform.CurrentPlatform);
                    var binary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
                    var profile = new FirefoxProfile();
                    break;
                case BrowserType.Chrome:
                    dc.SetCapability(CapabilityType.BrowserName, "chrome");
                    break;
            }
            _parallelConfig.Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), dc);
        }
    }
}
