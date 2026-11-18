namespace Mantenimiento.Application.Equipment.DTOs;

public record CreateEquipmentRequest(
    string Code,
    string Name,
    string Area,
    bool Active
);