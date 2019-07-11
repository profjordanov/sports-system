using Jbet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jbet.Persistence.EntityFramework
{
    internal static class OnModelCreatingConfiguration
    {
        internal static void ConfigureGuidPrimaryKeys(this ModelBuilder builder)
        {
            builder
                .Entity<Comment>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .Entity<Match>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .Entity<Player>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .Entity<Team>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .Entity<UserMatchBet>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .Entity<Vote>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}