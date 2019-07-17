using RiskFirst.Hateoas;
using System;

namespace Jbet.Api.Hateoas.Resources.Base
{
    public interface IPolicy<TResource>
        where TResource : Resource
    {
        Action<LinksPolicyBuilder<TResource>> PolicyConfiguration { get; }
    }
}