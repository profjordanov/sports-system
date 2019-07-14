using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Jbet.Core.Base;
using Jbet.Core.HomeContext.Queries;
using Jbet.Domain.Entities;
using Jbet.Domain.Repositories;
using Jbet.Domain.Views.Home;
using Jbet.Domain.Views.Match;
using Jbet.Domain.Views.Team;

namespace Jbet.Business.HomeContext.QueryHandlers
{
    public class GetHomeDataHandler : IQueryHandler<GetHomeData, HomeView>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public GetHomeDataHandler(
            ITeamRepository teamRepository,
            IMatchRepository matchRepository,
            IMapper mapper)
        {
            _teamRepository = teamRepository;
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        public async Task<HomeView> Handle(GetHomeData request, CancellationToken cancellationToken)
        {
            var matches = await _matchRepository
                .TopTreeMatchesByBetsAsync()
                .ToList(cancellationToken);

            var teams = await _teamRepository.BestTreeTeamsByVoteAsync(cancellationToken);

            var topMatches = _mapper.Map<IEnumerable<Match>, IEnumerable<MatchView>>(matches);
            var bestTeams = _mapper.Map<IEnumerable<Team>, IEnumerable<TeamView>>(teams);

            return new HomeView(topMatches, bestTeams);
        }
    }
}