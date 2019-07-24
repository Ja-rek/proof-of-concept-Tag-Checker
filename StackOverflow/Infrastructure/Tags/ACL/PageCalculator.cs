using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Mediporta.StackOverflow.Infrastructure.Tags.ACL
{
    public class PagesCalculator
    {
        public static IEnumerable<PageInfo> Calculate(int rowsNumber)
        {
            const int maxPageSize = 100;

            var pages = new Collection<PageInfo>();

            if (rowsNumber < maxPageSize) return new PageInfo[] { new PageInfo(1, rowsNumber) };

            var pageNumber = (int)rowsNumber / maxPageSize;

            var restRows = rowsNumber - (pageNumber * maxPageSize);

            for (int i = 1; i < pageNumber +1; i++) pages.Add(new PageInfo(i, maxPageSize * i));

            if (restRows > 0) pages.Add(new PageInfo(pages.Max(x => x.Number) + 1, restRows));

            return pages;
        }
    }
}
