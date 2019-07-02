using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Panda.Core.Exceptions;

namespace Panda.Core.Module
{
    public class PdaModuleDescriptor
    {
        public Type Type { get; }
        public Assembly Assembly { get; }
        public Type[] Depends { get; }
        public PdaModule Instance { get; }
        public bool IsVisit { get; set; }

        public PdaModuleDescriptor([NotNull]Type moduleType,[NotNull]Type[] depends)
        {
            Type = moduleType;
            Assembly=Assembly.GetAssembly(moduleType);
            Depends = depends;

            CreateInstance(moduleType);
            Instance = CreateInstance(moduleType);
        }

        private PdaModule CreateInstance(Type moduleType)
        {
            if (moduleType.GetConstructors().All(a => a.GetParameters().Length != 0))
            {
                throw new PdaCoreException(
                    $"Cannot create an instance for type {moduleType.FullName}, because it has no parameterless constructor.");
            }

            var instance = Activator.CreateInstance(moduleType) as PdaModule;
            return instance ?? throw new PdaCoreException($"Cannot create an instance for type {moduleType.FullName}, because  is not inherited {typeof(PdaModule).FullName}");
        }
    }
}