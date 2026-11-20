namespace Mantenimiento.Domain.Entities;

public class MaintenanceOrder
{
    public int Id { get; set; }
    public int EquipmentId { get; set; }

    public Equipment? Equipment { get; set; }
    public string Description { get; set; } = string.Empty;
    public int MaintenanceOrderTypesId { get; set; }
    public MaintenanceOrderTypes? MaintenanceOrderTypes { get; set; }
    public int MaintenanceOrderStatusId { get; set; }
    public MaintenanceOrderStatus? MaintenanceOrderStatus { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; }

    

}