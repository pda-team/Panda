using System;
using System.Reflection.Metadata;
using Panda.Core.Module;
using Panda.SampleLib;

namespace Panda.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var mgr = new PdaModuleManager();
            mgr.Initialization(typeof(Module1));

            foreach (var item in mgr.GetAll())
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
