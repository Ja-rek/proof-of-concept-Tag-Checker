using NUnit.Framework;
using Mediporta.TagChecker.StackOverflow.Infrastructure;
using NLog;

namespace Mediporta.TagChecker.StackOverflow.IntegrationTests
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
