using Jbet.Domain._Base;
using System;
using System.ComponentModel.DataAnnotations;
using Jbet.Domain.Events.Comments;

namespace Jbet.Domain.Entities
{
    public class Comment : IAggregate
    {
        [Key]
        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        // References
        public Guid MatchId { get; set; }

        public virtual Match Match { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        // Events
        public UserCommentedMatch CommentMatch(
            string content,
            DateTime createdOn,
            Guid matchId,
            Guid userId) => new UserCommentedMatch
        {
            CommentId = Id,
            Content = content,
            UserId = userId,
            MatchId = matchId,
            CreatedOn = createdOn
        };

        public void Apply(UserCommentedMatch @event)
        {
            Id = @event.CommentId;
            Content = @event.Content;
            CreatedOn = @event.CreatedOn;
            MatchId = @event.MatchId;
            UserId = @event.UserId;
        }
    }
}
