using System;
using Panda.Core.Exceptions;
using Panda.Core.Module;
using Xunit;

namespace Panda.Core.Tests.Module
{
    public class ModuleLoadTests
    {
        [Fact]
        public void LoadAllModules_ShouldBeSuccess()
        {
            // Module1: 2 3 4 5
            // Module2: 4
            // Module3: 5
            // Module4:
            // Module5: 2 4
            var mgr = new PdaModuleManager();
            mgr.Initialization(typeof(Module1));

            var modules = mgr.GetAll();
            Assert.Equal(5,modules.Count);
        }

        [Fact]
        public void LoadAllModules_NoEnterPoint_ShouldBeException()
        {
            // Module6: 7
            // Module7: 6
            var mgr = new PdaModuleManager();
            var exp = Assert.Throws<PdaCoreException>(() => mgr.Initialization(typeof(Module6)));
            Assert.Equal("Unable to find dependent entrance, no module has a dependency count of 0.", exp.Message);
        }

        [Fact]
        public void LoadAllModules_LoopDepend_ShouldBeException()
        {
            // Module8: 9 10
            // Module9: 8
            // Module10: 
            var mgr = new PdaModuleManager();
            var exp = Assert.Throws<PdaCoreException>(() => mgr.Initialization(typeof(Module8)));
            Assert.Equal("Loop dependencies found during module loading.", exp.Message);
        }
    }
}
