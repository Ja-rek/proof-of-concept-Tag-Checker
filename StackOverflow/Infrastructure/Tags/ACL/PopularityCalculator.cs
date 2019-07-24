namespace Mediporta.StackOverflow.Infrastructure.Tags.ACL
{
    public class PopularityCalculator
    {
        public static float CalculateProcent(int tagPopularity, int allTagPopularity)
        {
            return (float)tagPopularity / allTagPopularity * 100;
        }
    }
}
