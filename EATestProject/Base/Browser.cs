using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework.Base
{
    public class Browser
    {
        private ParallelConfig _parallelConfig;
        public Browser(ParallelConfig parallelConfig) { 
            _parallelConfig = parallelConfig;
        }

        public BrowserType Type { get; set; }

    }

    public enum BrowserType
    {
        InternetExplorer,
        FireFox,
        Chrome
    }
}
