namespace Mantenimiento.Application.Equipment.DTOs;

using MediatR;
using Mantenimiento.Domain.Entities;

public sealed record DeleteEquipmentRequest(
    int Id
): IRequest<Equipment?>;