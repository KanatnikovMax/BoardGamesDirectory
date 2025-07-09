using BoardGamesDirectory.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesDirectory.DataAccess;

public class BoardGamesDirectoryDbContext : DbContext
{
    public DbSet<BoardGame> BoardGames { get; set; }
    
    public BoardGamesDirectoryDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BoardGame>().HasKey(x => x.Id);
        modelBuilder.Entity<BoardGame>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<BoardGame>().HasIndex(x => x.Name).IsUnique();
    }
}