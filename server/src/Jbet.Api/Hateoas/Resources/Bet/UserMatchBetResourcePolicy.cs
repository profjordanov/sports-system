using System;
using Jbet.Api.Hateoas.Resources.Base;
using RiskFirst.Hateoas;

namespace Jbet.Api.Hateoas.Resources.Bet
{
    public class UserMatchBetResourcePolicy : IPolicy<UserMatchBetResource>
    {
        public Action<LinksPolicyBuilder<UserMatchBetResource>> PolicyConfiguration => policy =>
        {
            policy.RequireSelfLink();
        };
    }
}