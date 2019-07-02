using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Panda.Core.Exceptions;

namespace Panda.Core.Module
{
    internal class PdaModuleFinder
    {

        public static List<PdaModuleDescriptor> LoadAllModules(Type startModule)
        {
            CheckModuleType(startModule);
            var moduleDescriptors = new List<PdaModuleDescriptor>();

            FillModules(moduleDescriptors,startModule);

            var sortModuleDesc = SortModules(moduleDescriptors);

            return sortModuleDesc;
        }

        /// <summary>
        /// Find all module
        /// </summary>
        /// <param name="originalModuleDescriptors"></param>
        /// <param name="type"></param>
        private static void FillModules(List<PdaModuleDescriptor> originalModuleDescriptors,Type type)
        {
            CheckModuleType(type);

            //Avoid loop dependencies causing stack overflow
            if (originalModuleDescriptors.Any(a => a.Type == type))
            {
                return;
            }

            var moduleDependsAttr = type.GetCustomAttribute<DependsOnAttribute>();
            if (moduleDependsAttr == null || moduleDependsAttr.GetDependedTypes().Length == 0)
            {
                originalModuleDescriptors.Add(new PdaModuleDescriptor(type, new Type[0]));
                return;
            }

            var moduleDepends = moduleDependsAttr.GetDependedTypes();
            originalModuleDescriptors.Add(new PdaModuleDescriptor(type, moduleDepends));
            foreach (var dep in moduleDepends)
            {
                FillModules(originalModuleDescriptors,dep);
            }
        }

        /// <summary>
        /// Topological sort
        /// </summary>
        private static List<PdaModuleDescriptor> SortModules(List<PdaModuleDescriptor> originalModuleDescriptors)
        {
            var sortModuleDescriptors=new List<PdaModuleDescriptor>();

            originalModuleDescriptors.ForEach(a=>a.IsVisit=false);

            if (originalModuleDescriptors.All(a => a.Depends.Length != 0))
            {
                throw new PdaCoreException("Unable to find dependent entrance, no module has a dependency count of 0.");
            }

            while (originalModuleDescriptors.Exists(a=>a.IsVisit==false))
            {
                foreach (var item in originalModuleDescriptors.Where(t => t.Depends.Length == 0))
                {
                    sortModuleDescriptors.Add(item);
                    item.IsVisit = true;
                }

                var lastCount = originalModuleDescriptors.Count(t => !t.IsVisit);
                while (originalModuleDescriptors.Any(t => !t.IsVisit))
                {
                    var currentProcModules = originalModuleDescriptors.Where(t => !t.IsVisit).ToList();
                    foreach (var item in currentProcModules)
                    {
                        var count = item.Depends.Count(itemDepend => sortModuleDescriptors.Any(a => a.Type.FullName == itemDepend.FullName));

                        if (count != item.Depends.Length) continue;
                        sortModuleDescriptors.Add(item);
                        item.IsVisit = true;
                    }

                    var unVisitCount = originalModuleDescriptors.Count(t => !t.IsVisit);
                    if (unVisitCount == lastCount&& unVisitCount!=0)
                    {
                        throw new PdaCoreException("Loop dependencies found during module loading.");
                    }
                    else
                    {
                        lastCount = originalModuleDescriptors.Count(t => !t.IsVisit);
                    }
                }
            }

            return sortModuleDescriptors;
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