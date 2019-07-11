using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Jbet.Business.Base;
using Jbet.Core.Base;
using Jbet.Domain;
using Jbet.Domain.Entities;
using Jbet.Domain.Events.Base;
using Jbet.Domain.Repositories;
using MediatR;
using Optional;

namespace Jbet.Business.AuthContext.CommandHandlers
{
    public abstract class BaseAuthHandler<TCommand> : BaseHandler<TCommand>
        where TCommand : ICommand
    {
        protected BaseAuthHandler(
            IValidator<TCommand> validator,
            IEventBus eventBus,
            IMapper mapper,
            IUserRepository userRepository)
            : base(validator, eventBus, mapper)
        {
            UserRepository = userRepository;
        }

        protected IUserRepository UserRepository { get; }

        protected async Task<Option<User, Error>> AccountShouldExist(Guid accountId) =>
            (await UserRepository
                .GetAsync(accountId))
            .WithException(Error.NotFound($"No account with id {accountId} was found."));

        protected Task<Unit> ReplaceClaim(User account, string claimType, string claimValue) =>
            UserRepository.ReplaceClaimAsync(account, claimType, claimValue);
    }
}