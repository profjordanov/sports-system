using AutoMapper;
using FluentValidation;
using Jbet.Core.AuthContext.Commands;
using Jbet.Domain;
using Jbet.Domain.Entities;
using Jbet.Domain.Events.Base;
using Jbet.Domain.Repositories;
using MediatR;
using Optional;
using Optional.Async.Extensions;
using System.Threading.Tasks;

namespace Jbet.Business.AuthContext.CommandHandlers
{
    public class RegisterHandler : BaseAuthHandler<Register>
    {
        public RegisterHandler(
            IValidator<Register> validator,
            IEventBus eventBus,
            IMapper mapper,
            IUserRepository userRepository)
            : base(validator, eventBus, mapper, userRepository)
        {
        }

        public override Task<Option<Unit, Error>> Handle(Register command) =>
            CheckIfUserDoesntExist(command.Email).FlatMapAsync(_ =>
                PersistUser(command));

        private Task<Option<Unit, Error>> PersistUser(Register command)
        {
            var user = Mapper.Map<User>(command);
            return UserRepository.RegisterAsync(user, command.Password);
        }

        private async Task<Option<bool, Error>> CheckIfUserDoesntExist(string email)
        {
            var user = await UserRepository.GetByEmailAsync(email);

            return user
                .HasValue
                .SomeWhen(x => x == false, Error.Conflict($"User with email {email} already exists."));
        }
    }
}