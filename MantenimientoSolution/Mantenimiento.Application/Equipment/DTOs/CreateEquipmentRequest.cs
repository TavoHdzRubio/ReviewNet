namespace Mantenimiento.Application.Equipment.DTOs;
using MediatR;
public record CreateEquipmentRequest(
    string Code,
    string Name,
    string Area,
    bool Active
): IRequest<int>;