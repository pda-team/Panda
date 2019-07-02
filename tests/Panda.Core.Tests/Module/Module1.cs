using Panda.Core.Module;

namespace Panda.Core.Tests.Module
{
    [DependsOn(typeof(Module2), typeof(Module3), typeof(Module4), typeof(Module5))]
    public class Module1:PdaModule
    {
        public Module1()
        {
        }
    }
}