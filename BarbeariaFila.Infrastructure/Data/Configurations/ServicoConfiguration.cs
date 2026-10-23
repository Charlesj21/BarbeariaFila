using BarbeariaFila.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarbeariaFila.Infrastructure.Data.Configurations;

public class ServicoConfiguration : IEntityTypeConfiguration<Servico>
{
    public void Configure(EntityTypeBuilder<Servico> builder)
    {
        builder.ToTable("Servicos");

        builder.HasKey(servico => servico.Id);

        builder.Property(servico => servico.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(servico => servico.DuracaoMinutos)
            .IsRequired();
    }
}