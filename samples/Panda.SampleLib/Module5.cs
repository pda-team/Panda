using Panda.Core.Module;

namespace Panda.SampleLib
{
    [DependsOn(typeof(Module2), typeof(Module3), typeof(Module4))]
    public class Module5:PdaModule
    {
        
    }
}