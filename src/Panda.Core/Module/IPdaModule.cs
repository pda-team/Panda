using Panda.Core.DependencyInjection;

namespace Panda.Core.Module
{
    public interface IPdaModule:ISingletonDependency
    {
        void ConfigureServices(ServiceConfigurationContext context);
    }
}