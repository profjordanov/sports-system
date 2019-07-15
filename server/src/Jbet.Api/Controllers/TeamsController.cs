using Jbet.Api.Hateoas.Resources.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jbet.Api.Controllers
{
    /// <summary>
    /// A controller responsible for teams data.
    /// </summary>
    public class TeamsController : ApiController
    {
        public TeamsController(IMediator mediator, IResourceMapper resourceMapper)
            : base(mediator, resourceMapper)
        {
        }
    }
}