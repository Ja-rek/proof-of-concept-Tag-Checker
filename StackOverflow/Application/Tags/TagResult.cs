namespace Mediporta.TagChecker.StackOverflow.Application.Tags
{
    public class TagResult
    {
        public TagResult(string name, long count, float popularity)
        {
            Name = name;
            Count = count;
            Popularity = popularity;
        }

        public string Name { get; }
        public long Count { get; }
        public float Popularity { get; }
    }
}
