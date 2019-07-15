using Jbet.Domain.Events.Base;
using System;

namespace Jbet.Domain.Events.Votes
{
    public class UserVotedForTeam : IEvent
    {
        public Guid VoteId { get; set; }

        public Guid TeamId { get; set; }

        public Guid UserId { get; set; }

        public int Value { get; } = 1;
    }
}