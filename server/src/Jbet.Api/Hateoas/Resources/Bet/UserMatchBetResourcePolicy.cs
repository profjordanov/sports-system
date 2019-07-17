using Jbet.Api.Hateoas.Resources.Base;
using RiskFirst.Hateoas;
using System;

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