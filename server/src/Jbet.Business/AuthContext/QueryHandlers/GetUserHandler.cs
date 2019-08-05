using Jbet.Core.AuthContext.Queries;
using Jbet.Core.Base;
using Jbet.Domain;
using Jbet.Domain.Repositories;
using Jbet.Domain.Views;
using Optional;
using System.Threading;
using System.Threading.Tasks;

namespace Jbet.Business.AuthContext.QueryHandlers
{
    public class GetUserHandler : IQueryHandler<GetUser, Option<UserView, Error>>
    {
        private readonly IUserViewRepository _userViewRepository;
        public GetUserHandler(IUserViewRepository userViewRepository)
        {
            _userViewRepository = userViewRepository;
        }

        public async Task<Option<UserView, Error>> Handle(GetUser request, CancellationToken cancellationToken) =>
            (await _userViewRepository.GetAsync(request.Id))
            .WithException(Error.NotFound($"No user with id {request.Id} was found."));
    }
}