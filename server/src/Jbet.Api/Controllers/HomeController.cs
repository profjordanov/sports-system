using Jbet.Api.Hateoas.Resources.Base;
using Jbet.Api.Hateoas.Resources.Home;
using Jbet.Core.HomeContext.Queries;
using Jbet.Domain.Views.Home;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Jbet.Api.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// A controller responsible for the home page of the application.
    /// </summary>
    [AllowAnonymous]
    public class HomeController : ApiController
    {
        /// <inheritdoc />
        public HomeController(
            IMediator mediator,
            IResourceMapper resourceMapper)
            : base(mediator, resourceMapper)
        {
        }

        /// <summary>
        /// The root of the API.
        /// </summary>
        /// <returns>
        /// Top 3 matches (having most bets) and best 3 teams (most voted).
        /// </returns>
        /// <response code="200"></response>
        [HttpGet("index", Name = nameof(ApiHome))]
        [ProducesResponseType(typeof(HomeResource), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ApiHome()
        {
            var view = await Mediator.Send(new GetHomeData());
            var resource = await ToResourceAsync<HomeView, HomeResource>(view);
            return Ok(resource);
        }
    }
}