using System.Collections.Generic;
using Mediporta.TagChecker.StackOverflow.Infrastructure.Persistence.DataModel;

namespace Mediporta.TagChecker.StackOverflow.Application.Tags
{
    public interface ITagStorageService
    {
        void Save(IEnumerable<TagData> tags);
    }
}
