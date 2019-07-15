using Jbet.Core.Base;
using Jbet.Core.CommentContext.HttpRequests;
using System;

namespace Jbet.Core.CommentContext.Commands
{
    public class CommentMatch : CommentInput, ICommand
    {
        public CommentMatch(CommentInput input, Guid userId)
        {
            Content = input.Content;
            MatchId = input.MatchId;
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}