namespace Mantenimiento.Infrastructure.Persistence.Configurations;

using Mantenimiento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MaintenanceOrderStatusConfigurations : IEntityTypeConfiguration<MaintenanceOrderStatus>
{
    public void Configure(EntityTypeBuilder<MaintenanceOrderStatus> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.HasData(
            new MaintenanceOrderStatus { Id = 1, Name = "Pendiente" },
            new MaintenanceOrderStatus { Id = 2, Name = "En Proceso" },
            new MaintenanceOrderStatus { Id = 3, Name = "Completada" }
        );
    }
}
