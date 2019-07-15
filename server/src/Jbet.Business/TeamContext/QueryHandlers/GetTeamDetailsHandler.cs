using AutoMapper;
using Jbet.Core.Base;
using Jbet.Core.TeamContext.Queries;
using Jbet.Domain;
using Jbet.Domain.Entities;
using Jbet.Domain.Repositories;
using Jbet.Domain.Views.Team;
using Optional;
using System.Threading;
using System.Threading.Tasks;

namespace Jbet.Business.TeamContext.QueryHandlers
{
    public class GetTeamDetailsHandler : IQueryHandler<GetTeamDetails, Option<TeamDetailsView, Error>>
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;
        private readonly IVotesRepository _votesRepository;

        public GetTeamDetailsHandler(
            IMapper mapper,
            ITeamRepository teamRepository,
            IVotesRepository votesRepository)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
            _votesRepository = votesRepository;
        }

        public async Task<Option<TeamDetailsView, Error>> Handle(
            GetTeamDetails request,
            CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetByIdAsync(request.TeamId);
            if (team == null)
            {
                return Option.None<TeamDetailsView, Error>(
                    Error.NotFound($"No team with id {request.TeamId} was found."));
            }

            var result = _mapper.Map<Team, TeamDetailsView>(team);
            result.UserHasVoted = await _votesRepository
                .HasAnyByTeamAndUserAsync(request.TeamId, request.CurrentUserId);

            return result.Some<TeamDetailsView, Error>();
        }
    }
}