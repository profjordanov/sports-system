using Jbet.Domain.Entities;
using Jbet.Persistence.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Jbet.Business.Base;
using Jbet.Domain.Events.Base;

namespace Jbet.Api.Configuration
{
    internal static class DependenciesConfiguration
    {
        internal static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException(nameof(connectionString));
            }

            services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseNpgsql(connectionString));
        }

        internal static void AddJwtIdentity(
            this IServiceCollection services,
            IConfigurationSection jwtConfiguration,
            Action<AuthorizationOptions> config)
        {
            services.AddIdentity<User, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }

        public static void AddCqrs(this IServiceCollection services)
        {
            services.AddScoped<IEventBus, EventBus>();
        }
    }
}