using System.ComponentModel.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging.Abstractions;
using Panda.Core.Exceptions;
using Panda.Core.Module;
using Xunit;

namespace Panda.Core.Tests.Module
{
    public class ModuleCallTests
    {

        IServiceCollection services;
        IConfigurationRoot configuration;
        public ModuleCallTests()
        {
            configuration = new ConfigurationBuilder().Build();
            services = new ServiceCollection();
        }
        [Fact]
        public void TriggeredConfigureServicesTests()
        {
            var mgr = new PdaModuleManager();
            mgr.Initialization(typeof(Module1));
            mgr.TriggeredConfigureServices(new ServiceConfigurationContext(services,new HostingEnvironment(),new NullLoggerFactory(), configuration));
        }
    }
}