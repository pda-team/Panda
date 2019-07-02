using Panda.Core.Module;

namespace Panda.Core.Tests.Module
{
    [DependsOn(typeof(Module9), typeof(Module10))]
    public class Module8:PdaModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}