using System.Collections.Generic;
using Mediporta.StackOverflow.Infrastructure.Persistence.DataModel;

namespace Mediporta.StackOverflow.Application.Tags
{
    public interface ITagStorageService
    {
        void Save(IEnumerable<TagData> tags);
    }
}
