using System;
using System.ComponentModel.DataAnnotations;

namespace Jbet.Core.CommentContext.HttpRequests
{
    public class CommentInput
    {
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public Guid MatchId { get; set; }
    }
}