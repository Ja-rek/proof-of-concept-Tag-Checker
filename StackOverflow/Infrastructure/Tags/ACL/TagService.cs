using System.Collections.Generic;
using System.Threading.Tasks;
using Mediporta.StackOverflow.Infrastructure.Persistence.DataModel;
using Mediporta.StackOverflow.Application.Tags;
using System.Collections.Concurrent;
using NLog;
using Newtonsoft.Json;

namespace Mediporta.StackOverflow.Infrastructure.Tags.ACL
{
    public class TagService : ITagService
    {
        private readonly TagAdapter adapter;

        private Logger logger = LogManager.GetCurrentClassLogger();

        public TagService(TagAdapter adapter)
        {
            this.adapter = adapter;
        }

        public IEnumerable<TagData> GetMostPopulateTags(int tagsNumber)
        {
            var pagesInfo = PagesCalculator.Calculate(tagsNumber);

            var allTags = new ConcurrentBag<TagItemResource>();

            Parallel.ForEach(pagesInfo, pageInfo => 
            {
                var tags = this.adapter.GetMostPopularTags(pageInfo.Number, pageInfo.Size);

                foreach (var tag in tags)
                {
                    allTags.Add(tag);
                }
            });

            this.logger.Debug("Recived tags: " + JsonConvert.SerializeObject(allTags, Formatting.Indented));

            return new Translator().Translate(allTags);
        }
    }
}
