using System;
using System.Collections.Generic;
using Panda.Core.DependencyInjection;

namespace Panda.Core.Module
{
    public interface IPdaModuleManager:ISingletonDependency
    {
        void Initialization(Type startModule);

        IReadOnlyList<Type> GetAll();

        bool IsRegisted(Type module);
    }
}