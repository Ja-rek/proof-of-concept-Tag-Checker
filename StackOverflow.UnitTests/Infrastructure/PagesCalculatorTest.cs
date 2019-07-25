using System.Collections.Generic;
using System.Collections.ObjectModel;
using Mediporta.TagChecker.StackOverflow.Infrastructure.Tags.ACL;
using NUnit.Framework;

namespace Mediporta.TagChecker.StackOverflow.UnitTests.Infrastructure
{
    internal class PagesCalculatorTest
    {
        [Test]
        public void Calculate_WhenNumberOfRowsIs150_ThenShuldReturnCorrectList()
        {
            var actual = PagesCalculator.Calculate(150);
            var expected = new Collection<PageInfo> { new PageInfo(1, 100), new PageInfo(2, 50) }; 

            CollectionAssert.AreEqual(expected, actual, new PageInfoComparer());
        }

        [Test]
        public void Calculate_WhenNumberOfRowsIs100_ThenShuldReturnCorrectList()
        {
            var actual = PagesCalculator.Calculate(88);
            var expected = new Collection<PageInfo> { new PageInfo(1, 88) }; 

            CollectionAssert.AreEqual(expected, actual, new PageInfoComparer());
        }

        [Test]
        public void Calculate_WhenNumberOfRowsIs200_ThenShuldReturnCorrectList()
        {
            var actual = PagesCalculator.Calculate(200);
            var expected = new Collection<PageInfo> { new PageInfo(1, 100), new PageInfo(2, 200) }; 

            CollectionAssert.AreEqual(expected, actual, new PageInfoComparer());
        }

        private class PageInfoComparer : Comparer<PageInfo>
        {
            public override int Compare(PageInfo x, PageInfo y)
            {
                return x.Number.CompareTo(y.Number) & x.Size.CompareTo(y.Size);
            }
        }
    }

}
