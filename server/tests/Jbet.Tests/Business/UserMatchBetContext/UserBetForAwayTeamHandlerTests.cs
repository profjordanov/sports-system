using AutoFixture;
using AutoFixture.Kernel;
using Jbet.Core.AuthContext.Commands;
using Jbet.Core.UserMatchBetContext.Commands;
using Jbet.Domain.Entities;
using Jbet.Tests.Business.AuthContext;
using Jbet.Tests.Business.MatchContext.Helpers;
using Jbet.Tests.Customizations;
using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Jbet.Tests.Business.UserMatchBetContext
{
    public class UserBetForAwayTeamHandlerTests : ResetDatabaseLifetime
    {
        private readonly AppFixture _fixture;
        private readonly AuthTestsHelper _authTestsHelper;
        private readonly MatchTestHelper _matchTestHelper;

        public UserBetForAwayTeamHandlerTests()
        {
            _fixture = new AppFixture();
            _authTestsHelper = new AuthTestsHelper(_fixture);
            _matchTestHelper = new MatchTestHelper(_fixture);
        }

        [Theory]
        [CustomizedAutoData]
        public async Task UserCanBetForAwayTeam(
            Fixture fixture,
            Team homeTeam,
            Team awayTeam,
            Register registerCommand)
        {
            // Arrange
            await _authTestsHelper
                .RegisterAndLogin(registerCommand);

            var match = await _matchTestHelper
                .RegistrateMatchAsync(fixture, homeTeam, awayTeam);

            var betCommand = new UserBetForAwayTeam
            {
                UserId = registerCommand.Id,
                MatchId = match.Id,
                AwayBet = fixture.Create<decimal>(),
            };

            // Act
            var result = await _fixture.SendAsync(betCommand);

            // Assert
            var isBetExists = await _fixture.ExecuteDbContextAsync(
                async context =>
                context.UserMatchBets
                    .Any(bet => bet.UserId == registerCommand.Id &&
                                bet.MatchId == match.Id &&
                                bet.AwayBet == betCommand.AwayBet &&
                                bet.HomeBet == 0));

            isBetExists.ShouldBeTrue();
        }
    }
}