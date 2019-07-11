using Jbet.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Jbet.Persistence.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<UserMatchBet> UserMatchBets { get; set; }

        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureGuidPrimaryKeys();
            builder.ConfigureUserCommentsRelations();
            builder.ConfigureMatchCommentsRelations();
            builder.ConfigureTeamMatchRelations();
            builder.ConfigureTeamPlayerRelations();

            base.OnModelCreating(builder);
        }
    }
}