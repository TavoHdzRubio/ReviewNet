namespace Mantenimiento.Application.Equipment.DTOs;

public sealed record EquipmentResponse(
    int Id,
    string Code,
    string Name,
    string Area,
    bool Active,
    DateTime? UpdatedAt
);