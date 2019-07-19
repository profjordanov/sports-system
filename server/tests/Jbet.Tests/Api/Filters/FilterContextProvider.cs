using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using Jbet.Api.Filters;
using Jbet.Domain;
using Jbet.Tests.Customizations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Shouldly;
using Xunit;

namespace Jbet.Tests.Api.Filters
{
    public static class FilterContextProvider
    {
        public static ActionExecutingContext GetActionExecutingContext(string requestMethod)
        {
            var actionContext = GetFakeActionContext(requestMethod);

            var filterContext = A.Fake<ActionExecutingContext>(context => context.WithArgumentsForConstructor(() => new ActionExecutingContext(
                actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                A.Fake<Controller>())));

            return filterContext;
        }

        private static ActionContext GetFakeActionContext(string requestMethod = null)
        {
            var httpContext = A.Fake<HttpContext>();
            httpContext.Request.Method = requestMethod ?? "GET";

            var actionContext = new ActionContext
            {
                HttpContext = httpContext,
                RouteData = A.Fake<RouteData>(),
                ActionDescriptor = A.Fake<ActionDescriptor>(),
            };
            return actionContext;
        }
    }
}