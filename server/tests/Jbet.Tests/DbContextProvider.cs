using Jbet.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Jbet.Tests
{
    public static class DbContextProvider
    {
        private const string TestDbConnectionString =
            "PORT = 5432; HOST = localhost; TIMEOUT = 15; " +
            "POOLING = True; MINPOOLSIZE = 1; MAXPOOLSIZE = 100; COMMANDTIMEOUT = 20; " +
            "DATABASE = 'jbet-relational-tests'; PASSWORD = 'postgres'; USER ID = 'postgres'";

        public static ApplicationDbContext GetNpgsqlServerDbContext() =>
            new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseNpgsql(TestDbConnectionString)
                .Options);
    }
}