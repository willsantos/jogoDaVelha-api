using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WIlson.JogoDaVelha.Domain.Entities;

namespace Wilson.JogoDaVelha.Repository.Mapping;

public class PlayerEntityMap : IEntityTypeConfiguration<PlayerEntity>
{
    public void Configure(EntityTypeBuilder<PlayerEntity> builder)
    {
        builder.HasKey(prop => prop.Id);
        builder.ToTable("players");
    }
}