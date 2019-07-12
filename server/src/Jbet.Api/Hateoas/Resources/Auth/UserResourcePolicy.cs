using System;
using Jbet.Api.Controllers;
using Jbet.Api.Hateoas.Resources.Base;
using RiskFirst.Hateoas;

namespace Jbet.Api.Hateoas.Resources.Auth
{
    public class UserResourcePolicy : IPolicy<UserResource>
    {
        public Action<LinksPolicyBuilder<UserResource>> PolicyConfiguration => policy =>
        {
            
        };
    }
}