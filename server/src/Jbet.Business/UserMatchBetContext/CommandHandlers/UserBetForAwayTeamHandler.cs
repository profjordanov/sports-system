using AutoMapper;
using FluentValidation;
using Jbet.Business.Base;
using Jbet.Core.UserMatchBetContext.Commands;
using Jbet.Domain;
using Jbet.Domain.Events.Base;
using Jbet.Domain.Repositories;
using MediatR;
using Optional;
using Optional.Async.Extensions;
using System.Threading.Tasks;

namespace Jbet.Business.UserMatchBetContext.CommandHandlers
{
    public class UserBetForAwayTeamHandler : BaseHandler<UserBetForAwayTeam>
    {
        private readonly IBetsRepository _betsRepository;
        public UserBetForAwayTeamHandler(IValidator<UserBetForAwayTeam> validator, IEventBus eventBus, IMapper mapper, IBetsRepository betsRepository) : base(validator, eventBus, mapper)
        {
            _betsRepository = betsRepository;
        }

        public override Task<Option<Unit, Error>> Handle(UserBetForAwayTeam command) =>
            _betsRepository.AddAwayBetAsync(command.UserId, command.MatchId, command.AwayBet)
                .SomeNotNullAsync(Error.Critical("SWR"))
                .MapAsync(bet => PublishEvents(bet.Id, bet.UserBetForAwayTeam()));
    }
}