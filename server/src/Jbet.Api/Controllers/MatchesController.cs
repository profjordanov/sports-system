using Jbet.Api.Hateoas.Resources.Base;
using Jbet.Api.Hateoas.Resources.Match;
using Jbet.Core.MatchContext.Queries;
using Jbet.Domain.Views.Match;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Jbet.Api.Controllers
{
    /// <summary>
    /// A controller responsible for matches data.
    /// </summary>
    public class MatchesController : ApiController
    {
        public MatchesController(
            IMediator mediator,
            IResourceMapper resourceMapper)
            : base(mediator, resourceMapper)
        {
        }

        /// <summary>
        /// Display the matches, ordered by date with paging.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>A collection of <see cref="MatchView"/></returns>
        /// <response code="200"></response>
        [AllowAnonymous]
        [HttpGet("index", Name = nameof(Index))]
        [ProducesResponseType(typeof(IEnumerable<MatchResource>), (int)HttpStatusCode.OK)]
        public Task<IActionResult> Index([FromQuery] GetAllMatches query) =>
            ResourceContainerResult<MatchView, MatchResource, MatchContainerResource>(query);
    }
}