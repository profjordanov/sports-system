using Jbet.Domain.Entities;
using System.Threading.Tasks;

namespace Jbet.Tests.Business.TeamContext.Helpers
{
    public class TeamTestsHelper
    {
        private readonly AppFixture _fixture;

        public TeamTestsHelper(AppFixture fixture)
        {
            _fixture = fixture;
        }

        public Task<Team> AddAsync(Team team) =>
             _fixture.ExecuteDbContextAsync(
                async context =>
                {
                    await context.Teams.AddAsync(team);
                    await context.SaveChangesAsync();
                    return team;
                });
    }
}