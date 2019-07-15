using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Jbet.Business.Base;
using Jbet.Core.VoteContext.Commands;
using Jbet.Domain;
using Jbet.Domain.Entities;
using Jbet.Domain.Events.Base;
using Jbet.Domain.Repositories;
using MediatR;
using Optional;
using Optional.Async.Extensions;

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

        public override Task<Option<Unit, Error>> Handle(VoteForTeam command) =>
            SimilarVoteShouldNotExist(command).FlatMapAsync(_ =>
            SaveToRelationalDatabase(command).MapAsync(vote =>
            PublishEvents(vote.Id, vote.VoteForTeam(command.TeamId, command.UserId))));

        private Task<Option<Unit, Error>> SimilarVoteShouldNotExist(VoteForTeam command) =>
            _votesRepository.HasAnyByTeamAndUserAsync(command.TeamId, command.UserId)
                .SomeWhenAsync(b => !b, Error.Conflict($"Similar vote already exists."))
                .MapAsync(_ => Task.FromResult(Unit.Value));

        private Task<Option<Vote, Error>> SaveToRelationalDatabase(VoteForTeam command) =>
            _votesRepository.AddAsync(command.TeamId, command.UserId, CancellationToken.None)
                .SomeNotNullAsync(Error.Critical("Something went wrong!"));
    }
}