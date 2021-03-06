﻿using Jbet.Domain.Entities;
using Jbet.Domain.Repositories;
using Jbet.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Jbet.Persistence.Repositories
{
    public class BetsRepository : IBetsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BetsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<UserMatchBet> AddHomeBetAsync(
            Guid userId,
            Guid matchId,
            decimal homeBet) =>
            AddAsync(userId, matchId, homeBet, 0);

        public Task<UserMatchBet> AddAwayBetAsync(
            Guid userId,
            Guid matchId,
            decimal awayBet) =>
            AddAsync(userId, matchId, 0, awayBet);

        public async Task<UserMatchBet> AddAsync(
            Guid userId,
            Guid matchId,
            decimal homeBet,
            decimal awayBet)
        {
            var entity = new UserMatchBet
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                MatchId = matchId,
                AwayBet = awayBet,
                HomeBet = homeBet
            };

            await _dbContext.UserMatchBets.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public decimal SumAwayBetsByMatchId(Guid matchId) =>
            _dbContext
                .UserMatchBets
                .AsNoTracking()
                .Where(bet => bet.MatchId == matchId)
                .Sum(bet => bet.AwayBet);

        public decimal SumHomeBetsByMatchId(Guid matchId) =>
            _dbContext
                .UserMatchBets
                .AsNoTracking()
                .Where(bet => bet.MatchId == matchId)
                .Sum(bet => bet.HomeBet);
    }
}