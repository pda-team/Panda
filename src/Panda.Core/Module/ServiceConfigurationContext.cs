using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Panda.Core.Module
{
    public class ServiceConfigurationContext
    {
        public IServiceCollection Services { get; }

        public IHostingEnvironment Environment { get; }

        public ILoggerFactory LoggerFactory { get; }

        public IConfiguration Configuration { get; }

        public ServiceConfigurationContext([NotNull] IServiceCollection services,
            [NotNull] IHostingEnvironment environment,
            [NotNull] ILoggerFactory loggerFactory,
            [NotNull] IConfiguration configuration )
        {
            Services = services;
            Environment = environment;
            LoggerFactory = loggerFactory;
            Configuration = configuration;
        }
    }
}