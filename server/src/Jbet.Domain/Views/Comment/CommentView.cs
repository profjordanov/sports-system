using System;

namespace Jbet.Domain.Views.Comment
{
    public class CommentView
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Username { get; set; }
    }
}