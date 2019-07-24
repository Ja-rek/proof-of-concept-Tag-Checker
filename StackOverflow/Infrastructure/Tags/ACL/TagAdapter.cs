using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NLog;
using RestSharp;

namespace Mediporta.StackOverflow.Infrastructure.Tags.ACL
{
    public class TagAdapter
    {
        private readonly RestClient client;
        private Logger logger = LogManager.GetCurrentClassLogger();

        public TagAdapter(RestClient client)
        {
            this.client = client;
        }

        internal async Task<IEnumerable<TagItemResource>> GetMostPopularTags(PageInfo page)
        {
            var endpoint = $"tags?pagesize={page.Size}&page={page.Number}&order=desc&sort=popular&site=stackoverflow";

            this.logger.Debug($"Request for tags: {endpoint}");

            var request = new RestRequest(endpoint);

            var response = await this.client.GetAsync<TagsResource>(request);

            return response.Tags;
        }
    }
}
