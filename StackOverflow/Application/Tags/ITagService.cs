using System.Collections.Generic;
using System.Threading.Tasks;
using Mediporta.TagChecker.StackOverflow.Infrastructure.Persistence.DataModel;

namespace Mediporta.TagChecker.StackOverflow.Application.Tags
{
    public interface ITagService
    {
        Task<IEnumerable<TagData>> GetMostPopulateTags(int tagsNumber);
    }
}
