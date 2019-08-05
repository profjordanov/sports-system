using Jbet.Core.AuthContext.Commands;
using Jbet.Core.VoteContext.Commands;
using Jbet.Domain.Entities;
using Jbet.Domain.Events.Votes;
using Jbet.Tests.Business.AuthContext;
using Jbet.Tests.Customizations;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Jbet.Tests.Api.Hubs
{
    public class TeamVotesHubTests : ResetDatabaseLifetime
    {
        private readonly AppFixture _fixture;
        private readonly AuthTestsHelper _authTestsHelper;
        private readonly string _hubUrl;

        public TeamVotesHubTests()
        {
            _fixture = new AppFixture();
            _authTestsHelper = new AuthTestsHelper(_fixture);
            _hubUrl = _fixture.GetCompleteServerUrl("/teamVotes");
        }

        [Theory]
        [CustomizedAutoData]
        public async Task UserTeamVotesAreSentToAllSubscribers(
            Register registerCommand,
            Team teamToVote)
        {
            // Arrange
            await _authTestsHelper.Register(registerCommand);

            await _fixture.ExecuteDbContextAsync(async dbContext =>
            {
                await dbContext.Teams.AddAsync(teamToVote);
                await dbContext.SaveChangesAsync();
            });

            var testConnection = BuildTestConnection();

            var voteForTeamCommand = new VoteForTeam(teamToVote.Id, registerCommand.Id);

            // Act
            await _fixture.SendAsync(voteForTeamCommand);

            // Assert
            testConnection
                .VerifyMessageReceived(
                    team => team.UserId == voteForTeamCommand.UserId &&
                            team.TeamId == voteForTeamCommand.TeamId,
                    Times.Never());
        }

        private TestHubConnection<UserVotedForTeam> BuildTestConnection() =>
            new TestHubConnectionBuilder<UserVotedForTeam>()
                .WithHub(_hubUrl)
                .WithExpectedMessage(nameof(UserVotedForTeam))
                .Build();
    }
}