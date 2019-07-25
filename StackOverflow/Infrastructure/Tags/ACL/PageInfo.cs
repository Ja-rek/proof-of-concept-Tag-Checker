namespace Mediporta.TagChecker.StackOverflow.Infrastructure.Tags.ACL
{
    public class PageInfo
    {
        public PageInfo(int number, int size)
        {
            Number = number;
            Size = size;
        }

        public int Number { get; }
        public int Size { get; }
    }
}
