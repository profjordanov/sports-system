using Jbet.Api.Hateoas.Resources.Base;
using Jbet.Api.Hateoas.Resources.Vote;
using Jbet.Core.VoteContext.Commands;
using Jbet.Core.VoteContext.HttpRequests;
using Jbet.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Optional.Async.Extensions;
using System.Net;
using System.Threading.Tasks;

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

        /// <summary>
        /// Logged-in user votes for a team (no more than once).
        /// </summary>
        /// <response code="201">A vote was created.</response>
        /// <response code="409">User already voted.</response>
        [HttpPost(Name = nameof(Vote))]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> Vote([FromBody]VoteInput input) =>
            (await Mediator.Send(new VoteForTeam(input.TeamId, CurrentUserId))
                .MapAsync(_ => ToEmptyResourceAsync<VoteForTeamResource>()))
                .Match(unit => CreatedAtAction(nameof(Vote), unit), Error);
    }
}