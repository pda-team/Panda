using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace Panda.Core.Module
{
    public class PdaModuleManager:IPdaModuleManager
    {
        private List<PdaModuleDescriptor> _modules;

        private Type _startModule;

        public PdaModuleManager()
        {
            _modules = new List<PdaModuleDescriptor>();
        }


        public void Initialization(Type startModule)
        {
            _startModule = startModule;
            _modules = PdaModuleFinder.LoadAllModules(startModule);
        }

        public bool IsRegisted([NotNull]Type module)
        {
            return _modules.Any(a=>a.Type.FullName==module.FullName);
        }

        public IReadOnlyList<Type> GetAll()
        {
            return _modules.Select(a=>a.Type).ToList();
        }

        public void TriggeredPreConfigureServices(ServiceConfigurationContext context)
        {
            foreach (var item in _modules)
            {
                item.Instance.PreConfigureServices(context);
            }
        }

        public void TriggeredConfigureServices(ServiceConfigurationContext context)
        {
            foreach (var item in _modules)
            {
                item.Instance.ConfigureServices(context);
            }
        }

        public void TriggeredPostConfigureServices(ServiceConfigurationContext context)
        {
            foreach (var item in _modules)
            {
                item.Instance.PostConfigureServices(context);
            }
        }

        public void TriggeredPreApplicationInitialization(ApplicationInitializationContext context)
        {
            foreach (var item in _modules)
            {
                item.Instance.OnPreApplicationInitialization(context);
            }
        }

        public void TriggeredApplicationInitialization(ApplicationInitializationContext context)
        {
            foreach (var item in _modules)
            {
                item.Instance.OnApplicationInitialization(context);
            }
        }

        public void TriggeredPostApplicationInitialization(ApplicationInitializationContext context)
        {
            foreach (var item in _modules)
            {
                item.Instance.OnPostApplicationInitialization(context);
            }
        }

        public void TriggeredPostApplicationInitialization(ApplicationShutdownContext context)
        {
            foreach (var item in _modules)
            {
                item.Instance.OnApplicationShutdown(context);
            }
        }
    }
}