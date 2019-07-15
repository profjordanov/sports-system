using System;
using AutoMapper;
using Jbet.Core.Base;
using Jbet.Core.MatchContext.Queries;
using Jbet.Domain;
using Jbet.Domain.Entities;
using Jbet.Domain.Repositories;
using Jbet.Domain.Views.Match;
using Optional;
using Optional.Async.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace Jbet.Business.MatchContext.QueryHandlers
{
    public class GetMatchDetailsHandler : IQueryHandler<GetMatchDetails, Option<MatchDetailsView, Error>>
    {
        private readonly IMapper _mapper;
        private readonly IMatchRepository _matchRepository;

        public GetMatchDetailsHandler(IMapper mapper, IMatchRepository matchRepository)
        {
            _mapper = mapper;
            _matchRepository = matchRepository;
        }

        public Task<Option<MatchDetailsView, Error>> Handle(
            GetMatchDetails request,
            CancellationToken cancellationToken) =>
            _matchRepository.GetByIdAsync(request.Id)
                .SomeNotNullAsync(Error.NotFound($"No match with id {request.Id} was found."))
                .MapAsync(async match => SafetyMap(match));

        private MatchDetailsView SafetyMap(Match match)
        {
            try
            {
                return _mapper.Map<Match, MatchDetailsView>(match);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}