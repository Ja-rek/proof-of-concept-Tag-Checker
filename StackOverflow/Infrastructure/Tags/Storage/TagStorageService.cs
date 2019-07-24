using System.Collections.Generic;
using Mediporta.StackOverflow.Application.Tags;
using Mediporta.StackOverflow.Infrastructure.Persistence.DataModel;
using NHibernate;

namespace Mediporta.StackOverflow.Infrastructure.Tags.Storage
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
