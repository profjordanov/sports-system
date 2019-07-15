using Jbet.Domain.Entities;
using Jbet.Domain.Repositories;
using Jbet.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jbet.Persistence.Repositories
{
    public class VotesRepository : IVotesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VotesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> HasAnyByTeamAndUserAsync(Guid teamId, Guid userId) =>
            _dbContext
                .Votes
                .AnyAsync(vote => vote.TeamId == teamId &&
                                  vote.UserId == userId);

        public async Task<Vote> AddAsync(
            Guid teamId,
            Guid userId,
            CancellationToken cancellationToken)
        {
            var entity = new Vote
            {
                Id = Guid.NewGuid(),
                TeamId = teamId,
                UserId = userId,
                Value = 1
            };

            await _dbContext.Votes.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}