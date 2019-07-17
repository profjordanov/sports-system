using Jbet.Api.Hateoas.Resources.Base;
using Jbet.Api.Hateoas.Resources.Team;
using Jbet.Core.TeamContext.Queries;
using Jbet.Domain;
using Jbet.Domain.Views.Team;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Optional.Async.Extensions;
using System;
using System.Net;
using System.Threading.Tasks;

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

        /// <summary>
        /// Retrieves information about the team and its players.
        /// </summary>
        /// <response code="200">The team was found.</response>
        /// <response code="404">The team was not found.</response>
        [HttpGet("{id}", Name = nameof(TeamDetails))]
        [ProducesResponseType(typeof(TeamDetailsResource), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> TeamDetails([FromRoute] Guid id) =>
            (await Mediator.Send(new GetTeamDetails(id, CurrentUserId))
                .MapAsync(ToResourceAsync<TeamDetailsView, TeamDetailsResource>))
                .Match(Ok, Error);
    }
}