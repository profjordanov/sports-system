using FluentValidation;

namespace Jbet.Core.CommentContext.Commands
{
    public class CommentMatchValidator : AbstractValidator<CommentMatch>
    {
        public CommentMatchValidator()
        {
            RuleFor(comment => comment.Content).NotNull();
            RuleFor(comment => comment.UserId).NotNull();
            RuleFor(comment => comment.MatchId).NotNull();
        }
    }
}