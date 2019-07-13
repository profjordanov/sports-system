using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Jbet.Api.Configuration
{
    internal static class MiddlewareConfiguration
    {
        public static void UseSwagger(this IApplicationBuilder app, string endpointName)
        {
            app.UseSwagger();
            app.UseSwaggerUI(setup =>
            {
                setup.RoutePrefix = string.Empty;

                setup.SwaggerEndpoint(
                    url: "/swagger/v1/swagger.json",
                    name: endpointName);
            });
        }

        internal static void AddLogging(this ILoggerFactory loggerFactory, IConfigurationSection loggingConfiguration)
        {
            loggerFactory.AddConsole(loggingConfiguration);
            loggerFactory.AddFile("logs/jbet-api-{Date}.log");
            loggerFactory.AddDebug();
        }

        private static void UseSwaggerOn(this IApplicationBuilder app, string route, string endpointName)
        {
            app.UseSwaggerUI(setup =>
            {
                setup.RoutePrefix = route;

                setup.IndexStream = () => typeof(Startup)
                    .Assembly
                    .GetManifestResourceStream("Jbet.Api.Resources.Swagger.index.html");

                setup.SwaggerEndpoint(
                    url: "/swagger/v1/swagger.json",
                    name: endpointName);
            });
        }
    }
}