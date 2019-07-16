using Jbet.Core.Base;
using Jbet.Core.UserMatchBetContext.HttpRequests;
using System;

namespace Jbet.Core.UserMatchBetContext.Commands
{
    public class UserBetForHomeTeam : MatchHomeBetInput, ICommand
    {
        public UserBetForHomeTeam(MatchHomeBetInput input, Guid userId)
        {
            HomeBet = input.HomeBet;
            UserId = userId;
            MatchId = input.MatchId;
        }

        public Guid UserId { get; set; }
    }
}