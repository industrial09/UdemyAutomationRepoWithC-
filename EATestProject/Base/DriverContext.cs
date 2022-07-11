using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework.Base
{
    public class DriverContext
    {
        private ParallelConfig _parallelConfig;
        public DriverContext(ParallelConfig parallelConfig) {
            _parallelConfig = parallelConfig;
        }

        //public static Browser Browser { get; set; }

        public void GoToUrl(string url)
        {
            _parallelConfig.Driver.Url = url;
        }
    }
}
