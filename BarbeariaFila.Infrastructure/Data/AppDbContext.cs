using BarbeariaFila.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaFila.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Servico> Servicos => Set<Servico>();
    public DbSet<Barbeiro> Barbeiros => Set<Barbeiro>();
    public DbSet<ItemFila> ItensFila => Set<ItemFila>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}