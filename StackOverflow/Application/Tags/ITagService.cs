using System.Collections.Generic;
using System.Threading.Tasks;
using Mediporta.StackOverflow.Infrastructure.Persistence.DataModel;

namespace Mediporta.StackOverflow.Application.Tags
{
    public interface ITagService
    {
        Task<IEnumerable<TagData>> GetMostPopulateTags(int tagsNumber);
    }
}
