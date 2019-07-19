using Jbet.Api.Configuration;
using Jbet.Persistence.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Jbet.Tests.Api.Configuration
{
    public class DatabaseSeederTests : ResetDatabaseLifetime
    {
        private readonly AppFixture _fixture;

        public DatabaseSeederTests()
        {
            _fixture = new AppFixture();
        }


        [Fact]
        public Task ShouldSeedDatabase() =>
            _fixture.ExecuteScopeAsync(async sp =>
            {
                // Arrange
                var databaseSeeder = sp.GetService<DatabaseSeeder>();
                var dbContext = sp.GetService<ApplicationDbContext>();

                // Act
                await databaseSeeder.SeedDatabase();

                // Assert

                dbContext.Teams.Any().ShouldBeTrue();
                dbContext.Matches.Any().ShouldBeTrue();
                dbContext.Players.Any().ShouldBeTrue();
            });
    }
}