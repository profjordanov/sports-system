using FluentValidation;

namespace Jbet.Core.UserMatchBetContext.Commands
{
    public class UserBetForAwayTeamValidator : AbstractValidator<UserBetForAwayTeam>
    {
        public UserBetForAwayTeamValidator()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.MatchId).NotNull();
            RuleFor(x => x.AwayBet).NotNull();
        }
    }
}