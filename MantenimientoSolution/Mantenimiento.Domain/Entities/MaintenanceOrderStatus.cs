namespace Mantenimiento.Domain.Entities;

public class MaintenanceOrderStatus
{
    public int Id { get; set; }
    public string Name { get; set; }  = string.Empty;

    // Pendiente, EnProceso, Completada
}