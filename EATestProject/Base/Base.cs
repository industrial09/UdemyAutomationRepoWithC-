using System;
using TechTalk.SpecFlow;

namespace EAAutoFramework.Base
{
    public class Base
    {
        protected ParallelConfig _parallelConfig;
        public Base(ParallelConfig parallelConfig) { 
            _parallelConfig = parallelConfig;
        }

        public TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            return (TPage) Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}
