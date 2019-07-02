using Panda.Core.Module;

namespace Panda.Core.Tests.Module
{
    [DependsOn(typeof(Module8))]
    public class Module9:PdaModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}