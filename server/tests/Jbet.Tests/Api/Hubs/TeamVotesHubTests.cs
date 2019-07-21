using Jbet.Domain.Events.Votes;
using Xunit;

namespace Jbet.Tests.Api.Hubs
{
    public class TeamVotesHubTests : ResetDatabaseLifetime
    {
        private readonly AppFixture _fixture;
        private readonly string _hubUrl;

        public TeamVotesHubTests()
        {
            _fixture = new AppFixture();
            _hubUrl = _fixture.GetCompleteServerUrl("/teamVotes");
        }

        [Fact]
        public void Test()
        {
            var testConnection = BuildTestConnection();
        }

        private TestHubConnection<UserVotedForTeam> BuildTestConnection() =>
            new TestHubConnectionBuilder<UserVotedForTeam>()
                .WithHub(_hubUrl)
                .WithExpectedMessage(nameof(UserVotedForTeam))
                .Build();
    }
}