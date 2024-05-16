using HockeyLeague.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace HockeyLeague.Api.Data;

public class HockeyLeagueContext(DbContextOptions<HockeyLeagueContext> options)
    : DbContext(options)
{
    public DbSet<Team> Teams => Set<Team>();

    public DbSet<Division> Divisions => Set<Division>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Division>().HasData(
            new { Id = 1, Name = "One" },
            new { Id = 2, Name = "Two" },
            new { Id = 3, Name = "Three" }
        );
    }
}
