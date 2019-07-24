using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace Mediporta.StackOverflow.Infrastructure.Tags.ACL
{
    public class TagAdapter
    {
        private readonly RestClient client;

        public TagAdapter(RestClient client)
        {
            this.client = client;
        }

        internal IEnumerable<TagItemResource> GetMostPopularTags(int page, int pagesize)
        {
            var request = new RestRequest(
                $"tags&order=desc&sort=popular&site=stackoverflow&page={page}?pagesize={pagesize}");

            var tagResponse = this.client.Get<TagsResource>(request);

            if (tagResponse.IsSuccessful) return tagResponse.Data.Tags;

            return Enumerable.Empty<TagItemResource>();
        }
    }
}
