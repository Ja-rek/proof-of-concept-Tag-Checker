using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Mediporta.StackOverflow.Infrastructure.Tags.ACL
{
    public class TagItemResource
    {
        [DeserializeAs(Name = "count")]
        public int Count { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }
    }

    public class TagsResource
    {
        [DeserializeAs(Name = "items")]
        public IEnumerable<TagItemResource> Tags { get; set; }
    }
}
