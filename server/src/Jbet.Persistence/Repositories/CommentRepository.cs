using Jbet.Domain.Entities;
using Jbet.Domain.Repositories;
using Jbet.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Jbet.Persistence.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Comment> GetByMatchAndUserAsync(Guid matchId, Guid userId) =>
            _dbContext
                .Comments
                .FirstOrDefaultAsync(comment => comment.MatchId == matchId &&
                                                comment.UserId == userId);

        public async Task<Comment> AddAsync(string content, Guid matchId, Guid userId)
        {
            var entity = new Comment
            {
                Id = Guid.NewGuid(),
                Content = content,
                CreatedOn = DateTime.UtcNow,
                MatchId = matchId,
                UserId = userId
            };

            await _dbContext.Comments.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}