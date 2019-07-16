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
    public class UserBetForHomeTeamHandler : BaseHandler<UserBetForHomeTeam>
    {
        private readonly IBetsRepository _betsRepository;

        public UserBetForHomeTeamHandler(IValidator<UserBetForHomeTeam> validator, IEventBus eventBus, IMapper mapper, IBetsRepository betsRepository) : base(validator, eventBus, mapper)
        {
            _betsRepository = betsRepository;
        }

        public override Task<Option<Unit, Error>> Handle(UserBetForHomeTeam command) =>
            _betsRepository.AddHomeBetAsync(command.UserId, command.MatchId, command.HomeBet)
                .SomeNotNullAsync(Error.Critical("SWR"))
                .MapAsync(bet => PublishEvents(bet.Id, bet.UserBetForHomeTeam()));
    }
}