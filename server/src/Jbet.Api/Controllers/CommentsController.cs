using Jbet.Api.Hateoas.Resources.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jbet.Api.Controllers
{
    /// <summary>
    /// A controller responsible for comments for matches.
    /// </summary>
    public class CommentsController : ApiController
    {
        public CommentsController(IMediator mediator, IResourceMapper resourceMapper)
            : base(mediator, resourceMapper)
        {
        }
    }
}