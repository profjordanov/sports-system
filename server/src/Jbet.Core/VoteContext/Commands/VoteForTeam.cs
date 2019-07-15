using Jbet.Core.Base;
using System;

namespace Jbet.Core.VoteContext.Commands
{
    public class VoteForTeam : ICommand
    {
        public VoteForTeam(Guid teamId, Guid userId)
        {
            TeamId = teamId;
            UserId = userId;
        }

        public Guid TeamId { get; set; }

        public Guid UserId { get; set; }
    }
}