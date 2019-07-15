using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Jbet.Business.Base;
using Jbet.Core.VoteContext.Commands;
using Jbet.Domain;
using Jbet.Domain.Events.Base;
using Jbet.Domain.Repositories;
using MediatR;
using Optional;

namespace Jbet.Business.VoteContext.CommandHandlers
{
    public class VoteForTeamHandler : BaseHandler<VoteForTeam>
    {
        private readonly IVotesRepository _votesRepository;

        public VoteForTeamHandler(
            IValidator<VoteForTeam> validator,
            IEventBus eventBus,
            IMapper mapper,
            IVotesRepository votesRepository)
            : base(validator, eventBus, mapper)
        {
            _votesRepository = votesRepository;
        }

        public override Task<Option<Unit, Error>> Handle(VoteForTeam command)
        {
            throw new System.NotImplementedException();
        }
    }
}