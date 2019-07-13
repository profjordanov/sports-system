using System;
using System.Linq;
using System.Threading.Tasks;
using Jbet.Persistence.EntityFramework;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jbet.Api.Filters
{
    /// <inheritdoc />
    /// <summary>
    /// Starts an Entity Framework transaction before each action and commits it afterwards.
    /// </summary>
    public class EntityFrameworkTransactionFilter : IAsyncActionFilter
    {
        private readonly ApplicationDbContext _dbContext;

        public EntityFrameworkTransactionFilter(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await next();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}