namespace Mantenimiento.Infrastructure.Persistence.Configurations;

using Mantenimiento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MaintenanceOrderConfigurations : IEntityTypeConfiguration<MaintenanceOrder>
{
    public void Configure(EntityTypeBuilder<MaintenanceOrder> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).ValueGeneratedOnAdd();
        builder.Property(o => o.Description).IsRequired().HasMaxLength(500);
        builder.Property(o => o.CreatedAt).IsRequired();
        builder.Property(o => o.UpdatedAt).IsRequired(false);
        builder.Property(o => o.DeletedAt).IsRequired(false);

        builder.HasOne(x => x.MaintenanceOrderStatus)
            .WithMany()
            .HasForeignKey(x => x.MaintenanceOrderStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.MaintenanceOrderTypes)
            .WithMany()
            .HasForeignKey(x => x.MaintenanceOrderTypesId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Equipment)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.EquipmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}