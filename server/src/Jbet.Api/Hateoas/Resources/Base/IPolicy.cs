using System;
using RiskFirst.Hateoas;

namespace Jbet.Api.Hateoas.Resources.Base
{
    public interface IPolicy<TResource>
        where TResource : Resource
    {
        Action<LinksPolicyBuilder<TResource>> PolicyConfiguration { get; }
    }
}