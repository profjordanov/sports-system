using Jbet.Domain.Events.Base;
using System;

namespace Jbet.Domain.Events.Comments
{
    public class UserCommentedMatch : IEvent
    {
        public Guid CommentId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid MatchId { get; set; }

        public Guid UserId { get; set; }
    }
}