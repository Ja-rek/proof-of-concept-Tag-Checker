using NUnit.Framework;
using Mediporta.StackOverflow.Infrastructure;
using NLog;

namespace Mediporta.StackOverflow.IntegrationTests
{
    [SetUpFixture]
    internal class Setup
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            LogManager.Configuration = LogConfig.Config();
        }
    }
}
