using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Jbet.Domain._Base;

namespace Jbet.Domain.Entities
{
    public class Match : IAggregate
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime Start { get; set; }

        // References

        public Guid HomeTeamId { get; set; }

        public virtual Team HomeTeam { get; set; }

        public Guid AwayTeamId { get; set; }

        public virtual Team AwayTeam { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<UserMatchBet> UserMatchBets { get; set; }
    }
}