using Jbet.Api.Hateoas.Resources.Base;
using System;

namespace Jbet.Api.Hateoas.Resources.Match
{
    public class MatchResource : Resource
    {
        public Guid Id { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public DateTime Start { get; set; }
    }
}