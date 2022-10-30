using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WIlson.JogoDaVelha.Domain.Entities;

namespace Wilson.JogoDaVelha.Repository.Mapping;

public class PlayEntityMap : IEntityTypeConfiguration<PlayEntity>
{
    public void Configure(EntityTypeBuilder<PlayEntity> builder)
    {
        builder.HasKey(prop => prop.Id);
        builder.ToTable("plays");
    }
}