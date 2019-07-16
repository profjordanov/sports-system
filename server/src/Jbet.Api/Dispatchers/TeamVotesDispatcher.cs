using Jbet.Api.Hubs;
using Jbet.Domain.Events.Votes;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace Jbet.Api.Dispatchers
{
    public class TeamVotesDispatcher : INotificationHandler<UserVotedForTeam>
    {
        private readonly IHubContext<TeamVotesHub> _hubContext;

        public TeamVotesDispatcher(IHubContext<TeamVotesHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task Handle(UserVotedForTeam notification, CancellationToken cancellationToken) =>
            _hubContext
                .Clients
                .All
                .SendAsync(nameof(UserVotedForTeam), notification, cancellationToken);
    }
}