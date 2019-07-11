using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Jbet.Core.AuthContext;
using Jbet.Core.AuthContext.Commands;
using Jbet.Core.Base;
using Jbet.Domain;
using Jbet.Domain.Entities;
using Jbet.Domain.Repositories;
using Jbet.Domain.Views;
using Optional;
using Optional.Async.Extensions;
using Optional.Extensions;

namespace Jbet.Business.AuthContext.CommandHandlers
{
    public class LoginHandler : ICommandHandler<Login, JwtView>
    {
        private readonly IJwtFactory _jwtFactory;
        private readonly IUserRepository _userRepository;
        private readonly IValidator<Login> _validator;

        public LoginHandler(IUserRepository userRepository, IJwtFactory jwtFactory, IValidator<Login> validator)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
            _validator = validator;
        }

        public Task<Option<JwtView, Error>> Handle(Login command, CancellationToken cancellationToken = default) =>
            ValidateCommand(command).FlatMapAsync(cmd =>
            FindUser(command.Email).FlatMapAsync(user =>
            CheckPassword(user, command.Password).FlatMapAsync(_ =>
            GetExtraClaims(user).MapAsync(async claims =>
            GenerateJwt(user, claims)))));

        private async Task<Option<bool, Error>> CheckPassword(User user, string password)
        {
            var passwordIsValid = await _userRepository
                .CheckPasswordAsync(user, password);

            var result = passwordIsValid
                .SomeWhen(isValid => isValid, Error.Unauthorized("Invalid credentials."));

            return result;
        }

        private Task<Option<User, Error>> FindUser(string email) =>
            _userRepository
                .GetByEmailAsync(email)
                .WithExceptionAsync(Error.NotFound($"No user with email {email} was found."));

        private JwtView GenerateJwt(User user, IEnumerable<Claim> extraClaims) =>
            new JwtView
            {
                TokenString = _jwtFactory.GenerateEncodedToken(user.Id.ToString(), user.Email, extraClaims)
            };

        private Task<Option<IList<Claim>, Error>> GetExtraClaims(User user) =>
            user.SomeNotNull(Error.Validation($"You must provide a non-null user."))
                .MapAsync(u => _userRepository.GetClaimsAsync(u));

        // TODO: This is duplicated in BaseHandler.cs
        private Option<Login, Error> ValidateCommand(Login command)
        {
            var validationResult = _validator.Validate(command);

            return validationResult
                .SomeWhen(
                    r => r.IsValid,
                    r => Error.Validation(r.Errors.Select(e => e.ErrorMessage)))

                // If the validation result is successful, disregard it and simply return the command
                .Map(_ => command);
        }
    }
}