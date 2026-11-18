namespace Mantenimiento.Domain.Entities;

public class MaintenanceOrder
{
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public string Description { get; set; } = string.Empty;
    public int MaintenanceOrderTypesId { get; set; }
    public MaintenanceOrderTypes? MaintenanceOrderTypes { get; set; }
    public int MaintenanceOrderStatusId { get; set; }
    public MaintenanceOrderStatus? MaintenanceOrderStatus { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? deletionDate { get; set; }

    

}