using Microsoft.EntityFrameworkCore;
using WIlson.JogoDaVelha.Domain.Entities;
using Wilson.JogoDaVelha.Repository.Mapping;

namespace Wilson.JogoDaVelha.Repository;

public class ApiDbContext : DbContext
{
    public ApiDbContext() { }
    public DbSet<PlayerEntity> Players { get; set; }
    public DbSet<GameEntity> Games { get; set; }
    public DbSet<PlayEntity> Plays { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerEntity>(new PlayerEntityMap().Configure);
        modelBuilder.Entity<GameEntity>(new GameEntityMap().Configure);
        modelBuilder.Entity<PlayEntity>(new PlayEntityMap().Configure);
    }
    
    // public override int SaveChanges()
    // {
    //     var entries = ChangeTracker
    //         .Entries()
    //         .Where(e => e.Entity is BaseEntity && (
    //             e.State == EntityState.Added
    //             || e.State == EntityState.Modified));
    //
    //     foreach (var entityEntry in entries)
    //     {
    //         ((BaseEntity)entityEntry.Entity).UpdateAt = DateTime.Now;
    //
    //         if (entityEntry.State == EntityState.Added)
    //         {
    //             ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
    //         }
    //     }
    //
    //     return base.SaveChanges();
    // }
}