using Jbet.Api.Hateoas.Resources.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jbet.Api.Controllers
{
    /// <summary>
    /// A controller responsible for votes data.
    /// </summary>
    [Authorize]
    public class VotesController : ApiController
    {
        public VotesController(IMediator mediator, IResourceMapper resourceMapper)
            : base(mediator, resourceMapper)
        {
        }
    }
}