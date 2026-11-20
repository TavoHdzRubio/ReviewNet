namespace Mantenimiento.Application.Equipment.DTOs;

using MediatR;
using Mantenimiento.Domain.Entities;

public record GetEquipmentByIdRequest(
    int Id
): IRequest<Equipment?>;