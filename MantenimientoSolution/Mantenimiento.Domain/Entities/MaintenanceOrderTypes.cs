namespace Mantenimiento.Domain.Entities;

public class MaintenanceOrderTypes
{
    public int Id { get; set; }
    public string Name { get; set; }  = string.Empty;
    //  Preventivo o Correctivo
}