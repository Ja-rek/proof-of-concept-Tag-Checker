using System.Collections.Generic;
using System.Linq;
using Mediporta.TagChecker.StackOverflow.Infrastructure.Persistence.DataModel;

namespace Mediporta.TagChecker.StackOverflow.Infrastructure.Tags.ACL
{
    internal class Translator
    {
        public IEnumerable<TagData> Translate(IEnumerable<TagItemResource> tags)
        {
            var allTagsSum = tags.Sum(x => x.Count);

            return tags.Select(x => new TagData 
                { 
                    Id = x.Name, 
                    Count = x.Count, 
                    Popularity = PopularityCalculator.CalculateProcent(x.Count, allTagsSum)
                }
            );
        }
    }
}
