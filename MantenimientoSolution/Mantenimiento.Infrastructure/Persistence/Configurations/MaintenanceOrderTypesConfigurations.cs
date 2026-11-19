namespace Mantenimiento.Infrastructure.Persistence.Configurations;

using Mantenimiento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MaintenanceOrderTypesConfigurations : IEntityTypeConfiguration<MaintenanceOrderTypes>
{
    public void Configure(EntityTypeBuilder<MaintenanceOrderTypes> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.HasData(
            new MaintenanceOrderTypes { Id = 1, Name = "Preventivo" },
            new MaintenanceOrderTypes { Id = 2, Name = "Correctivo" }
        );
    }
}
