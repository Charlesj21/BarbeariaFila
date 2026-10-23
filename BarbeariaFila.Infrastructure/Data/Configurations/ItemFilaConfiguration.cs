using BarbeariaFila.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarbeariaFila.Infrastructure.Data.Configurations;

public class ItemFilaConfiguration : IEntityTypeConfiguration<ItemFila>
{
    public void Configure(EntityTypeBuilder<ItemFila> builder)
    {
        builder.ToTable("ItensFila");

        builder.HasKey(item => item.Id);

        builder.Property(item => item.Status)
            .IsRequired();

        builder.Property(item => item.ChegouEm)
            .IsRequired();

        builder.HasOne(item => item.Servico)
            .WithMany()
            .HasForeignKey(item => item.ServicoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}