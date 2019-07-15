using FluentValidation;

namespace Jbet.Core.VoteContext.Commands
{
    public class VoteForTeamValidator : AbstractValidator<VoteForTeam>
    {
        public VoteForTeamValidator()
        {
            RuleFor(vote => vote.TeamId).NotNull();
            RuleFor(vote => vote.UserId).NotNull();
        }
    }
}