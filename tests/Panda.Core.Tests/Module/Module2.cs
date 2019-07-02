using Panda.Core.Module;

namespace Panda.Core.Tests.Module
{
    [DependsOn(typeof(Module4))]
    public class Module2:PdaModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}