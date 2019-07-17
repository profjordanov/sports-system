using System.Net;
using System.Net.Sockets;
using Jbet.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jbet.Tests
{
    public class AppFixture
    {
        public static readonly string BaseUrl;
        private static readonly IConfiguration _configuration;
        private static readonly IServiceScopeFactory _scopeFactory;

        static AppFixture()
        {
            BaseUrl = $"http://localhost:{GetFreeTcpPort()}";

            var webhost = Program
                .CreateWebHostBuilder(new[] { "--environment", "IntegrationTests" }, BaseUrl)
                .Build();

            webhost.Start();

            var scopeFactory = (IServiceScopeFactory)webhost.Services.GetService(typeof(IServiceScopeFactory));

            _scopeFactory = scopeFactory;

            using (var scope = scopeFactory.CreateScope())
            {
                _configuration = scope.ServiceProvider.GetService<IConfiguration>();
            }
        }

        public static string EventStoreConnectionString => _configuration.GetSection("EventStore")["ConnectionString"];

        public static string RelationalDbConnectionString => _configuration.GetConnectionString("DefaultConnection");

        private static int GetFreeTcpPort()
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }
    }
}