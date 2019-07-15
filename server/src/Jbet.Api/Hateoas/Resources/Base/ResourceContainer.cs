using System.Collections.Generic;

namespace Jbet.Api.Hateoas.Resources.Base
{
    public class ResourceContainer<TResource> : Resource
        where TResource : Resource
    {
        public IEnumerable<TResource> Items { get; set; }
    }
}