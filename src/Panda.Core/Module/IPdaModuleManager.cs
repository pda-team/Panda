using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Panda.Core.DependencyInjection;

namespace Panda.Core.Module
{
    public interface IPdaModuleManager:ISingletonDependency
    {
        void Initialization(Type startModule);
        bool IsRegisted([NotNull]Type module);
        IReadOnlyList<Type> GetAll();
        void TriggeredPreConfigureServices(ServiceConfigurationContext context);
        void TriggeredConfigureServices(ServiceConfigurationContext context);
        void TriggeredPostConfigureServices(ServiceConfigurationContext context);
        void TriggeredPreApplicationInitialization(ApplicationInitializationContext context);
        void TriggeredApplicationInitialization(ApplicationInitializationContext context);
        void TriggeredPostApplicationInitialization(ApplicationInitializationContext context);
        void TriggeredPostApplicationInitialization(ApplicationShutdownContext context);
    }
}