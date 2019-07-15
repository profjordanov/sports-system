using Jbet.Core.Base;
using Jbet.Domain;
using Jbet.Domain.Views.Team;
using Optional;
using System;

namespace Jbet.Core.TeamContext.Queries
{
    public class GetTeamDetails : IQuery<Option<TeamDetailsView, Error>>
    {
        public GetTeamDetails(Guid teamId, Guid currentUserId)
        {
            TeamId = teamId;
            CurrentUserId = currentUserId;
        }

        public Guid TeamId { get; set; }

        public Guid CurrentUserId { get; set; }
    }
}
