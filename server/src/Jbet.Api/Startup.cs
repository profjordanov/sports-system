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

            services.AddMarten(Configuration);
            services.AddCqrs();
            services.AddMediatR();
            services.AddRepositories();

            services.AddMvc(options =>
            {
                options.Filters.Add<ExceptionFilter>();
                options.Filters.Add<ModelStateFilter>();
            })
            .AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<RegisterValidator>();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            UserManager<User> userManager,
            ApplicationDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            loggerFactory.AddLogging(Configuration.GetSection("Logging"));

            app.UseSwagger("Jbet");

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
