using Jbet.Domain._Base;
using System;
using System.ComponentModel.DataAnnotations;
using Jbet.Domain.Events.UserMatchBets;

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

        // Events
        public UserMadeHomeBet UserBetForHomeTeam() =>
            new UserMadeHomeBet
            {
                UserMatchBetId = Id,
                UserId = UserId,
                MatchId = MatchId,
                HomeBet = HomeBet
            };

        public void Apply(UserMadeHomeBet @event)
        {
            Id = @event.UserMatchBetId;
            MatchId = @event.MatchId;
            UserId = @event.UserId;
            HomeBet = @event.HomeBet;
            AwayBet = 0;
        }

        public UserMadeAwayBet UserBetForAwayTeam() =>
            new UserMadeAwayBet
            {
                UserMatchBetId = Id,
                UserId = UserId,
                MatchId = MatchId,
                AwayBet = AwayBet
            };

        public void Apply(UserMadeAwayBet @event)
        {
            Id = @event.UserMatchBetId;
            MatchId = @event.MatchId;
            UserId = @event.UserId;
            AwayBet = @event.AwayBet;
            HomeBet = 0;
        }
    }
}