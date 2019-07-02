using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace Panda.Core.Module
{
    public class PdaModuleDescriptor
    {
        public Type Type { get; }
        public Assembly Assembly { get; }
        public Type[] Depends { get; }
        public bool IsVisit { get; set; }

        public PdaModuleDescriptor([NotNull]Type moduleType,[NotNull]Type[] depends)
        {
            Type = moduleType;
            Assembly=Assembly.GetAssembly(moduleType);
            Depends = depends;
        }
    }
}