namespace Mantenimiento.Infrastructure.Persistence;

using Mantenimiento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Mantenimiento.Application.Interfaces;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<MaintenanceOrderStatus> MaintenanceOrderStatus { get; set; } = null!;
    public DbSet<MaintenanceOrderTypes> MaintenanceOrderTypes { get; set; } = null!;
    public DbSet<Equipment> Equipment { get; set; } = null!;
    public DbSet<MaintenanceOrder> MaintenanceOrder { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}

