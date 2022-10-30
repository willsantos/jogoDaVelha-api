using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WIlson.JogoDaVelha.Domain.Entities;

namespace Wilson.JogoDaVelha.Repository.Mapping;

public class GameEntityMap: IEntityTypeConfiguration<GameEntity>
{
    public void Configure(EntityTypeBuilder<GameEntity> builder)
    {
        builder.HasKey(prop => prop.Id);
        
        builder.ToTable("games");
    }
}