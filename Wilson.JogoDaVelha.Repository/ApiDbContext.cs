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
    }
}