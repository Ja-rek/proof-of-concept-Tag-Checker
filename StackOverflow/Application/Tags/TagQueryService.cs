using System.Collections.Generic;
using System.Linq;
using Mediporta.StackOverflow.Infrastructure.Persistence.DataModel;
using NHibernate;

namespace Mediporta.StackOverflow.Application.Tags
{
    public class TagQueryService
    {
        private readonly ISession session;

        public TagQueryService(ISession session)
        {
            this.session = session;
        }

        public IEnumerable<TagResult> GetMostPopulateTags()
        {
            var tags = session.QueryOver<TagData>().List();

            return tags.Select(x => new TagResult(x.Id, x.Count, x.Popularity));
        }
    }
}
