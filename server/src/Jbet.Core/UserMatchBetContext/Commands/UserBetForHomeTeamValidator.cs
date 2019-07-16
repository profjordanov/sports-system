using FluentValidation;

namespace Jbet.Core.UserMatchBetContext.Commands
{
    public class UserBetForHomeTeamValidator : AbstractValidator<UserBetForHomeTeam>
    {
        public UserBetForHomeTeamValidator()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.MatchId).NotNull();
            RuleFor(x => x.HomeBet).NotNull();
        }
    }
}