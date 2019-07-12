using System.Linq;
using Jbet.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jbet.Api.Filters
{
    public class ModelStateFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            var errors = context
                .ModelState
                .Values
                .SelectMany(v => v.Errors.Select(e => e.ErrorMessage));

            context.Result = new BadRequestObjectResult(Error.Validation(errors));
        }
    }
}