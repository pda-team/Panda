using System;
using System.Reflection;

namespace Panda.Core.Module
{
    public abstract class PdaModule:IPdaModule
    {
        public virtual void PreConfigureServices(ServiceConfigurationContext context)
        {

        }

        public abstract void ConfigureServices(ServiceConfigurationContext context);

        public virtual void PostConfigureServices(ServiceConfigurationContext context)
        {

        }


        public virtual void OnPreApplicationInitialization(ApplicationInitializationContext context)
        {

        }


        public virtual void OnApplicationInitialization(ApplicationInitializationContext context)
        {

        }

        public virtual void OnPostApplicationInitialization(ApplicationInitializationContext context)
        {

        }


        public virtual void OnApplicationShutdown(ApplicationShutdownContext context)
        {

        }
    }
}