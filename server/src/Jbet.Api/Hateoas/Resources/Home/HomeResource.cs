using System.Collections.Generic;
using Jbet.Api.Hateoas.Resources.Base;
using Jbet.Domain.Views.Match;
using Jbet.Domain.Views.Team;

namespace Jbet.Api.Hateoas.Resources.Home
{
    public class HomeResource : Resource
    {
        public IEnumerable<MatchView> TopMatches { get; set; }

        public IEnumerable<TeamView> BestTeams { get; set; }
    }
}