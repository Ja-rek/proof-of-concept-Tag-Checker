using System.Linq;
using Mediporta.StackOverflow.Application.Tags;
using NUnit.Framework;

namespace Mediporta.StackOverflow.IntegrationTests.Application
{
    internal class TagServiceTest
    {
        [Test]
        public void GetMostPopulateTags_WhenGet1000Tags_ThenReturns1000UnicateTags()
        {
            var tags = TagService().GetMostPopulateTags(1000);

            Assert.AreEqual(1000, tags.GroupBy(x => x.Id).Select(x => x.First()).Count());
        }

        [Test]
        public void GetMostPopulateTags_WhenGetTags_ThenTagsContainValues()
        {
            var tag = TagService().GetMostPopulateTags(1).First();

            Assert.NotZero(tag.Count);
            Assert.NotZero(tag.Popularity);
            Assert.AreNotEqual(tag.Id, string.Empty);
        }

        public ITagService TagService()
        {
            return ServiceLocator.Resolve<ITagService>();
        }
    }
}
