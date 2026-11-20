namespace Mantenimiento.Application.Equipment.DTOs;

using MediatR;

public sealed record GetEquipmentsRequest(
    string? Code,
    string? Name,
    string? Area,
    bool? Active,
    int? PageNumber,
    int? PageSize
): IRequest<IEnumerable<EquipmentResponse>>;
