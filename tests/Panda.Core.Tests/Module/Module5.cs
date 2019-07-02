using Panda.Core.Module;

namespace Panda.Core.Tests.Module
{
    [DependsOn(typeof(Module2), typeof(Module4))]
    public class Module5:PdaModule
    {
        
    }
}