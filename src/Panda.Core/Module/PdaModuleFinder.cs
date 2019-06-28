using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Panda.Core.Module
{
    internal class PdaModuleFinder
    {
        private static readonly List<PdaModuleDescriptor> ModuleDescriptors=new List<PdaModuleDescriptor>();

        public static List<Type> LoadAllModules(Type startModule)
        {
            CheckModuleType(startModule);
            ModuleDescriptors.Clear();

            FillModules(startModule);

            var result = ModuleDescriptors.Select(a=>a.Type).ToList();

            return result;
        }

        private static void FillModules(Type type)
        {
            CheckModuleType(type);


            //Avoid loop dependencies causing stack overflow
            if (ModuleDescriptors.Any(a => a.Type == type))
            {
                return;
            }

            var moduleDependsAttr = type.GetCustomAttribute<DependsOnAttribute>();
            if (moduleDependsAttr == null || moduleDependsAttr.GetDependedTypes().Length == 0)
            {
                ModuleDescriptors.Add(new PdaModuleDescriptor(type, new Type[0]));
                return;
            }

            var moduleDepends = moduleDependsAttr.GetDependedTypes();
            ModuleDescriptors.Add(new PdaModuleDescriptor(type, moduleDepends));
            foreach (var dep in moduleDepends)
            {
                FillModules(dep);
            }
        }

        private static bool IsModule(Type type)
        {
            var typeInfo = type.GetTypeInfo();

            return
                typeInfo.IsClass &&
                !typeInfo.IsAbstract &&
                !typeInfo.IsGenericType &&
                typeof(IPdaModule).GetTypeInfo().IsAssignableFrom(type);
        }

        private static void CheckModuleType(Type moduleType)
        {
            if (!IsModule(moduleType))
            {
                throw new ArgumentException("Given type is not an Panda module: " + moduleType.AssemblyQualifiedName);
            }
        }
    }
}