using System;
using System.Threading.Tasks;
using Jbet.Domain.Repositories;
using Jbet.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

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
    }
}