using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Kernel;
using Jbet.Api.Hateoas;
using Jbet.Api.Hateoas.Resources.Bet;
using Jbet.Core.UserMatchBetContext.HttpRequests;
using Jbet.Domain.Entities;
using Jbet.Tests.Business.AuthContext;
using Jbet.Tests.Business.MatchContext.Helpers;
using Jbet.Tests.Business.TeamContext.Helpers;
using Jbet.Tests.Customizations;
using Jbet.Tests.Extensions;
using Xunit;

namespace Jbet.Tests.Api.Controllers
{
    public class BetsControllerTests : ResetDatabaseLifetime
    {
        private readonly AppFixture _fixture;
        private readonly ApiTestsHelper _apiHelper;
        private readonly MatchTestHelper _matchTestHelper;

        public BetsControllerTests()
        {
            _fixture = new AppFixture();
            _apiHelper = new ApiTestsHelper(_fixture);
            _matchTestHelper = new MatchTestHelper(_fixture);
        }

        [Theory]
        [CustomizedAutoData]
        public async Task BetForAwayTeamShouldReturnProperHypermediaLinks(
            Fixture fixture,
            Team homeTeam,
            Team awayTeam) =>
            await _apiHelper.InTheContextOfAnAuthenticatedUser(
                async client =>
                {
                    // Arrange
                    var currentMatch = await _matchTestHelper
                        .RegistrateMatchAsync(fixture, homeTeam, awayTeam);

                    var httpRequest = new MatchAwayBetInput
                    {
                        MatchId = currentMatch.Id,
                        AwayBet = fixture.Create<decimal>(),
                    };

                    // Act
                    var response = await client.PostAsJsonAsync("/bets/away-team", httpRequest);

                    // Assert
                    var expectedLinks = new List<string>
                    {
                        LinkNames.Self
                    };

                    await response.ShouldBeAResource<UserMatchBetResource>(expectedLinks);

                }, fixture);

        [Theory]
        [CustomizedAutoData]
        public async Task BetForHomeTeamShouldReturnProperHypermediaLinks(
            Fixture fixture,
            Team homeTeam,
            Team awayTeam) =>
            await _apiHelper.InTheContextOfAnAuthenticatedUser(
                async client =>
                {
                    // Arrange
                    var currentMatch = await _matchTestHelper.RegistrateMatchAsync(fixture, homeTeam, awayTeam);

                    var httpRequest = new MatchHomeBetInput
                    {
                        MatchId = currentMatch.Id,
                        HomeBet = fixture.Create<decimal>(),
                    };

                    // Act
                    var response = await client.PostAsJsonAsync("/bets/home-team", httpRequest);

                    // Assert
                    var expectedLinks = new List<string>
                    {
                        LinkNames.Self
                    };

                    await response.ShouldBeAResource<UserMatchBetResource>(expectedLinks);

                }, fixture);
    }
}