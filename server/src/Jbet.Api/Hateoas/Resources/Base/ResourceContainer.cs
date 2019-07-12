using System.Collections.Generic;

namespace Jbet.Api.Hateoas.Resources.Base
{
    public class ResourceContainer<TResouce> : Resource
        where TResouce : Resource
    {
        public IEnumerable<TResouce> Items { get; set; }
    }
}