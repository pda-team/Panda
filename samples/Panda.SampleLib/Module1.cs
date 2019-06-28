using System;
using System.Reflection;
using Panda.Core.Module;

namespace Panda.SampleLib
{
    [DependsOn(typeof(Module2), typeof(Module3), typeof(Module4), typeof(Module5))]
    public class Module1:PdaModule
    {
        public Module1()
        {
        }
    }
}