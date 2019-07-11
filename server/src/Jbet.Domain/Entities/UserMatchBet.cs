using Jbet.Domain._Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Jbet.Domain.Entities
{
    public class UserMatchBet : IAggregate
    {
        [Key]
        public Guid Id { get; set; }

        public decimal HomeBet { get; set; }

        public decimal AwayBet { get; set; }

        // References

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public Guid MatchId { get; set; }

        public virtual Match Match { get; set; }
    }
}