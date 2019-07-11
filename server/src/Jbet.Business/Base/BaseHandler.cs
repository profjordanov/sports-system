using AutoMapper;
using FluentValidation;
using Jbet.Core.Base;
using Jbet.Domain;
using Jbet.Domain.Events.Base;
using MediatR;
using Optional;
using Optional.Async.Extensions;
using Optional.Extensions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Jbet.Business.Base
{
    public abstract class BaseHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        protected BaseHandler(
            IValidator<TCommand> validator,
            IEventBus eventBus,
            IMapper mapper)
        {
            Validator = validator ??
                        throw new InvalidOperationException(
                            "Tried to instantiate a command handler without a validator." +
                            "Did you forget to add one?");
            EventBus = eventBus;
            Mapper = mapper;
        }

        protected IEventBus EventBus { get; }
        protected IMapper Mapper { get; }
        protected IValidator<TCommand> Validator { get; }

        public Task<Option<Unit, Error>> Handle(TCommand command, CancellationToken cancellationToken) =>
            ValidateCommand(command)
                .FlatMapAsync(Handle);

        public abstract Task<Option<Unit, Error>> Handle(TCommand command);

        protected Task<Unit> PublishEvents(Guid streamId, params IEvent[] events) =>
            EventBus.Publish(streamId, events);

        protected Option<TCommand, Error> ValidateCommand(TCommand command)
        {
            var validationResult = Validator.Validate(command);

            return validationResult
                .SomeWhen(
                    r => r.IsValid,
                    r => Error.Validation(r.Errors.Select(e => e.ErrorMessage)))

                // If the validation result is successful, disregard it and simply return the command
                .Map(_ => command);
        }
    }
}