using System.Collections.Generic;
using Mediporta.TagChecker.StackOverflow.Application.Tags;
using Mediporta.TagChecker.StackOverflow.Infrastructure.Persistence.DataModel;
using NHibernate;

namespace Mediporta.TagChecker.StackOverflow.Infrastructure.Tags.Storage
{
    public class TagStorageService : ITagStorageService
    {
        private readonly ISession session;

        public TagStorageService(ISession session)
        {
            this.session = session;
        }

        public void Save(IEnumerable<TagData> tags)
        {
            using(var transaction = this.session.BeginTransaction())
            {
                foreach (var tag in tags) this.session.SaveOrUpdate(tag);

                transaction.Commit();
            }
        }
    }
}
