// <copyright file="CommentsController.cs" company="jjSoft Solutions LTD">
// Copyright (c) jjSoft Solutions LTD. All rights reserved.
// </copyright>

using Jbet.Api.Hateoas.Resources.Base;
using Jbet.Api.Hateoas.Resources.Comment;
using Jbet.Core.CommentContext.Commands;
using Jbet.Core.CommentContext.HttpRequests;
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
    /// A controller responsible for comments for matches.
    /// </summary>
    [Authorize]
    public class CommentsController : ApiController
    {
        public CommentsController(IMediator mediator, IResourceMapper resourceMapper)
            : base(mediator, resourceMapper)
        {
        }

        /// <summary>
        /// Logged-in users can add comments for given match.
        /// </summary>
        /// <response code="201">A comment was created.</response>
        /// <response code="409">User already comment.</response>
        [HttpPost(Name = nameof(Comment))]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> Comment([FromBody]CommentInput input) =>
            (await Mediator.Send(new CommentMatch(input, CurrentUserId))
                .MapAsync(_ => ToEmptyResourceAsync<CommentMatchResource>()))
            .Match(unit => CreatedAtAction(nameof(Comment), unit), Error);
    }
}