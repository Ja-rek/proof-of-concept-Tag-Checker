using System.Collections.Generic;
using System.Threading.Tasks;
using Mediporta.TagChecker.StackOverflow.Infrastructure.Persistence.DataModel;
using Mediporta.TagChecker.StackOverflow.Application.Tags;
using NLog;
using Newtonsoft.Json;
using System.Linq;

namespace Mediporta.TagChecker.StackOverflow.Infrastructure.Tags.ACL
{
    public class TagService : ITagService
    {
        private readonly TagAdapter adapter;
        private Logger logger = LogManager.GetCurrentClassLogger();

        public TagService(TagAdapter adapter)
        {
            this.adapter = adapter;
        }

        public async Task<IEnumerable<TagData>> GetMostPopulateTags(int tagsNumber)
        {
            var pagesInfo = PagesCalculator.Calculate(tagsNumber);

            var allTags = new List<TagItemResource>();

            var tasks = pagesInfo.Select(pageInfo => this.adapter.GetMostPopularTags(pageInfo));

            var batchsTag = await Task.WhenAll(tasks);

            foreach (var batchTag in batchsTag) 
            {
                if (batchTag != null) allTags.AddRange(batchTag);
            }

            this.logger.Debug("Recived tags: " + JsonConvert.SerializeObject(allTags, Formatting.Indented));

            return new Translator().Translate(allTags);
        }
    }
}
