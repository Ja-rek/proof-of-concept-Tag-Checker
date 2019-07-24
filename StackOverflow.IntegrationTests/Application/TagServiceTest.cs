using System.Linq;
using System.Threading.Tasks;
using Mediporta.StackOverflow.Application.Tags;
using NUnit.Framework;

namespace Mediporta.StackOverflow.IntegrationTests.Application
{
    internal class TagServiceTest
    {
        [Test]
        public async Task GetMostPopulateTags_WhenGet1000Tags_ThenReturns1000UnicateTags()
        {
            var tags = await TagService().GetMostPopulateTags(1000);

            Assert.AreEqual(1000, tags.GroupBy(x => x.Id).Select(x => x.First()).Count());
        }

        [Test]
        public async Task GetMostPopulateTags_WhenGetTags_ThenTagsContainValues()
        {
            var tags = await TagService().GetMostPopulateTags(1);
            var tag = tags.First();

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
