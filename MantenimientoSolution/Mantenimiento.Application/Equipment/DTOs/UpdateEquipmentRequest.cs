namespace Mantenimiento.Application.Equipment.DTOs;

using MediatR;

public record UpdateEquipmentRequest 
(
    int Id,
    string Code,
    string Name,
    string Area,
    bool Active
) : CreateEquipmentRequest (Code, Name, Area, Active), IRequest<int?>;