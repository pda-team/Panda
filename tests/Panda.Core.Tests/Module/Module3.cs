using Panda.Core.Module;

namespace Panda.Core.Tests.Module
{
    [DependsOn(typeof(Module5))]
    public class Module3:PdaModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}