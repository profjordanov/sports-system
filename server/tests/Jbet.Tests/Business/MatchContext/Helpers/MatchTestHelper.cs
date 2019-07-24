using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Kernel;
using Jbet.Domain.Entities;
using Jbet.Tests.Business.TeamContext.Helpers;

namespace Jbet.Tests.Business.MatchContext.Helpers
{
    public class MatchTestHelper
    {
        private readonly AppFixture _fixture;
        private readonly TeamTestsHelper _teamTestsHelper;

        public MatchTestHelper(AppFixture fixture)
        {
            _fixture = fixture;
            _teamTestsHelper = new TeamTestsHelper(fixture);
        }

        public async Task<Match> RegistrateMatchAsync(
            ISpecimenBuilder fixture,
            Team homeTeam,
            Team awayTeam)
        {
            var team1 = await _teamTestsHelper.AddAsync(homeTeam);
            var team2 = await _teamTestsHelper.AddAsync(awayTeam);

            var currentMatch = new Match
            {
                Id = Guid.NewGuid(),
                AwayTeamId = team2.Id,
                HomeTeamId = team1.Id,
                Start = fixture.Create<DateTime>(),
            };

            await _fixture.ExecuteDbContextAsync(async dbContext =>
            {
                await dbContext.Matches.AddAsync(currentMatch);
                await dbContext.SaveChangesAsync();
            });

            return currentMatch;
        }
    }
}