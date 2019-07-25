namespace Mediporta.TagChecker.StackOverflow.Infrastructure.Persistence.DataModel
{
    public class TagData
    {
        public virtual string Id { get; set; }
        public virtual long Count { get; set; }
        public virtual float Popularity { get; set; }
    }
}
