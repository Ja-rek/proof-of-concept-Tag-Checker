using Mediporta.StackOverflow.Infrastructure.Tags.ACL;
using NUnit.Framework;

namespace Tests.Infrastructure
{
    internal class PopularityCalculatorTest
    {
        [Test]
        public void CalculateProcent_ShuldReturnCorrectProcent()
        {
            var actual = PopularityCalculator.CalculateProcent(200, 60661);
            var expected = 0.329701126f;

            Assert.AreEqual(expected, actual);
        }
    }
}
