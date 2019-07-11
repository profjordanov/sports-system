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

        internal static void ConfigureUserCommentsRelations(this ModelBuilder builder)
        {
            builder
                .Entity<Comment>()
                .HasOne(comment => comment.User)
                .WithMany(user => user.Comments)
                .HasForeignKey(comment => comment.UserId);
        }

        internal static void ConfigureMatchCommentsRelations(this ModelBuilder builder)
        {
            builder
                .Entity<Comment>()
                .HasOne(comment => comment.Match)
                .WithMany(match => match.Comments)
                .HasForeignKey(comment => comment.MatchId);
        }

        internal static void ConfigureTeamMatchRelations(this ModelBuilder builder)
        {
            builder
                .Entity<Match>()
                .HasOne(match => match.AwayTeam)
                .WithMany(team => team.AwayMatches)
                .HasForeignKey(match => match.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Match>()
                .HasOne(match => match.HomeTeam)
                .WithMany(team => team.HomeMatches)
                .HasForeignKey(match => match.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        internal static void ConfigureTeamPlayerRelations(this ModelBuilder builder)
        {
            builder
                .Entity<Player>()
                .HasOne(player => player.Team)
                .WithMany(team => team.Players)
                .HasForeignKey(player => player.TeamId)
                .IsRequired(false);
        }

        internal static void ConfigureUserMatchBetsRelations(this ModelBuilder builder)
        {
            builder
                .Entity<UserMatchBet>()
                .HasOne(bet => bet.User)
                .WithMany(user => user.UserMatchBets)
                .HasForeignKey(bet => bet.UserId)
                .IsRequired();

            builder
                .Entity<UserMatchBet>()
                .HasOne(bet => bet.Match)
                .WithMany(match => match.UserMatchBets)
                .HasForeignKey(bet => bet.MatchId)
                .IsRequired();
        }

        internal static void ConfigureUserTeamVotesRelations(this ModelBuilder builder)
        {
            builder
                .Entity<Vote>()
                .HasOne(vote => vote.User)
                .WithMany(user => user.UserTeamVotes)
                .HasForeignKey(vote => vote.UserId)
                .IsRequired();

            builder
                .Entity<Vote>()
                .HasOne(vote => vote.Team)
                .WithMany(team => team.Votes)
                .HasForeignKey(vote => vote.TeamId)
                .IsRequired();
        }
    }
}