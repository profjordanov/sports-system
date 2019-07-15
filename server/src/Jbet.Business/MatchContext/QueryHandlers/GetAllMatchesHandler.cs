using AutoMapper;
using Jbet.Core.Base;
using Jbet.Core.MatchContext.Queries;
using Jbet.Domain.Entities;
using Jbet.Domain.Repositories;
using Jbet.Domain.Views.Match;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Jbet.Business.MatchContext.QueryHandlers
{
    public class GetAllMatchesHandler : IQueryHandler<GetAllMatches, IList<MatchView>>
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public GetAllMatchesHandler(IMatchRepository matchRepository, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        public async Task<IList<MatchView>> Handle(GetAllMatches request, CancellationToken cancellationToken)
        {
            var result = await _matchRepository
                .GetPagedListAsync(
                    cancellationToken: cancellationToken,
                    page: request.StartPage,
                    pageSize: request.Limit);

            return _mapper.Map<IList<Match>, IList<MatchView>>(result);
        }
    }
}