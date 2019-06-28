using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace Panda.Core.Module
{
    public class PdaModuleManager:IPdaModuleManager
    {
        private List<Type> _modules;

        private Type _startModule;

        public PdaModuleManager()
        {
            _modules = new List<Type>();
        }


        public void Initialization(Type startModule)
        {
            _startModule = startModule;
            _modules = PdaModuleFinder.LoadAllModules(startModule);
        }


        public bool IsRegisted([NotNull]Type module)
        {
            return _modules.Contains(module);
        }

        public IReadOnlyList<Type> GetAll()
        {
            return _modules;
        }
    }
}