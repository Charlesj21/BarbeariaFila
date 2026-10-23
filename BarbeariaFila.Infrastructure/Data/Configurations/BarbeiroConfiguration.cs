using BarbeariaFila.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarbeariaFila.Infrastructure.Data.Configurations;

public class BarbeiroConfiguration : IEntityTypeConfiguration<Barbeiro>
{
    public void Configure(EntityTypeBuilder<Barbeiro> builder)
    {
        builder.ToTable("Barbeiros");

        builder.HasKey(barbeiro => barbeiro.Id);

      

        builder.Property(barbeiro => barbeiro.Ativo)
            .IsRequired();
    }
}