using Panda.Core.Module;

namespace Panda.Core.Tests.Module
{
    [DependsOn(typeof(Module6))]
    public class Module7:PdaModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}