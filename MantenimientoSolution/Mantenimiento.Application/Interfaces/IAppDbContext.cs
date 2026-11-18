namespace Mantenimiento.Application.Interfaces;

using Mantenimiento.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public interface IAppDbContext
{
    DbSet<MaintenanceOrderStatus> MaintenanceOrderStatus { get; }
    DbSet<MaintenanceOrderTypes> MaintenanceOrderTypes { get; }
    DbSet<Equipment> Equipment { get; }
    DbSet<MaintenanceOrder> MaintenanceOrder { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}