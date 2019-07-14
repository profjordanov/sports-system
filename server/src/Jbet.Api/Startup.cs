using AutoMapper;
using FluentValidation.AspNetCore;
using Jbet.Api.Configuration;
using Jbet.Api.Filters;
using Jbet.Api.Hateoas.Resources.Auth;
using Jbet.Business.AuthContext.CommandHandlers;
using Jbet.Core.AuthContext;
using Jbet.Core.AuthContext.Commands;
using Jbet.Core.AuthContext.Configuration;
using Jbet.Domain.Entities;
using Jbet.Persistence.EntityFramework;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Jbet.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Adds services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext(Configuration.GetConnectionString("DefaultConnection"));

            services.AddJwtIdentity(
                Configuration.GetSection(nameof(JwtConfiguration)),
                options =>
                {
                    options.AddPolicy(AuthConstants.Policies.IsAdmin, pb => pb.RequireClaim(AuthConstants.ClaimTypes.IsAdmin));
                });

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfiles(typeof(MappingProfile).Assembly);
                cfg.AddProfiles(typeof(UserMappingProfile).Assembly);
            });

            services.AddSwagger();

            services.AddHateoas();

            services.AddLogging(logBuilder => logBuilder.AddSerilog(dispose: true));

            services.AddTransient<DatabaseSeeder>();

            services.AddMarten(Configuration);
            services.AddCqrs();
            services.AddMediatR();
            services.AddRepositories();

            services.AddMvc(options =>
            {
                options.Filters.Add<ExceptionFilter>();
                options.Filters.Add<ModelStateFilter>();

                options.Filters.Add(new EntityFrameworkTransactionFilter(
                    services
                        .BuildServiceProvider()
                        .GetService<ApplicationDbContext>()));
            })
            .AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<RegisterValidator>();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        /// <summary>
        /// This method gets called by the runtime.
        /// Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">
        /// Provides the mechanisms to configure an application's request pipeline.
        /// </param>
        /// <param name="env">
        /// Provides information about the web hosting environment an application is running in.
        /// </param>
        /// <param name="loggerFactory">
        /// Represents a type used to configure the logging system
        /// and create instances of ILogger from the registered ILoggerProviders.
        /// </param>
        /// <param name="userManager">
        /// Managing user in a persistence store.
        /// </param>
        /// <param name="dbContext">
        /// Application class for the Entity Framework database context used for identity.
        /// </param>
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            UserManager<User> userManager,
            ApplicationDbContext dbContext,
            DatabaseSeeder seeder)
        {
            // ensure data stores
            dbContext.Database.EnsureCreated();
            DatabaseConfiguration.EnsureEventStoreIsCreated(Configuration);

            if (!env.IsEnvironment(Environment.IntegrationTests))
            {
                DatabaseConfiguration.AddDefaultAdminAccountIfNoneExisting(userManager, Configuration).Wait();
                seeder.SeedDatabase().Wait();
            }

            if (!env.IsDevelopment())
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseCors(builder => builder
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .WithOrigins("http://localhost:3000", "https://jbet.net")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            loggerFactory.AddLogging(Configuration.GetSection("Logging"));

            app.UseSwagger("Jbet");

            app.UseStaticFiles();
            app.UseAuthentication();

            // soon app.UseSignalR

            app.UseMvc();
        }
    }
}
