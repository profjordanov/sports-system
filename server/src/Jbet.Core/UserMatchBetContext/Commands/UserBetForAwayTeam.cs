using Jbet.Core.Base;
using Jbet.Core.UserMatchBetContext.HttpRequests;
using System;

namespace Jbet.Core.UserMatchBetContext.Commands
{
    public class UserBetForAwayTeam : MatchAwayBetInput, ICommand
    {
        public UserBetForAwayTeam()
        {
        }

        public UserBetForAwayTeam(MatchAwayBetInput input, Guid userId)
        {
            MatchId = input.MatchId;
            UserId = userId;
            AwayBet = input.AwayBet;
        }

        public Guid UserId { get; set; }
    }
}