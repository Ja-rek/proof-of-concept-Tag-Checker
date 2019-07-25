using Autofac;
using Mediporta.TagChecker.StackOverflow.Infrastructure.ContainerIOC;

namespace Mediporta.TagChecker.StackOverflow.IntegrationTests
{
    internal class ServiceLocator
    {
        public static TService Resolve<TService>()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterAssemblyModules(typeof(StackOverflowIOC).Assembly);

            return builder.Build().BeginLifetimeScope().Resolve<TService>();
        }
    }
}
