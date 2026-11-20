namespace Mantenimiento.Domain.Entities;

public class Equipment
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Area { get; set; } = string.Empty;
    public bool Active { get; set; } = true;
    public DateTime? LastMaintenance { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; }

    public ICollection<MaintenanceOrder> Orders { get; set; } = new List<MaintenanceOrder>();
}