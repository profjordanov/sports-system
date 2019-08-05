// <copyright file="BetsController.cs" company="jjSoft Solutions LTD">
// Copyright (c) jjSoft Solutions LTD. All rights reserved.
// </copyright>

using Jbet.Api.Hateoas.Resources.Base;
using Jbet.Api.Hateoas.Resources.Bet;
using Jbet.Core.UserMatchBetContext.Commands;
using Jbet.Core.UserMatchBetContext.HttpRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Optional.Async.Extensions;
using System.Net;
using System.Threading.Tasks;

namespace Jbet.Api.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// A controller responsible for user's bets.
    /// </summary>
    [Authorize]
    public class BetsController : ApiController
    {
        public BetsController(IMediator mediator, IResourceMapper resourceMapper)
            : base(mediator, resourceMapper)
        {
        }

        /// <summary>
        /// Logged-in users can bet for the away team.
        /// </summary>
        /// <param name="input">HTTP request.</param>
        [HttpPost("away-team", Name = nameof(BetForAwayTeam))]
        [ProducesResponseType(typeof(UserMatchBetResource), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> BetForAwayTeam([FromBody] MatchAwayBetInput input) =>
            (await Mediator.Send(new UserBetForAwayTeam(input, CurrentUserId))
                .MapAsync(_ => ToEmptyResourceAsync<UserMatchBetResource>()))
                .Match(resource => CreatedAtAction(nameof(BetForAwayTeam), resource), Error);

        /// <summary>
        /// Logged-in users can bet for the home team.
        /// </summary>
        /// <param name="input">HTTP request.</param>
        [HttpPost("home-team", Name = nameof(BetForHomeTeam))]
        [ProducesResponseType(typeof(UserMatchBetResource), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> BetForHomeTeam([FromBody] MatchHomeBetInput input) =>
            (await Mediator.Send(new UserBetForHomeTeam(input, CurrentUserId))
                .MapAsync(_ => ToEmptyResourceAsync<UserMatchBetResource>()))
                .Match(resource => CreatedAtAction(nameof(BetForHomeTeam), resource), Error);
    }
}