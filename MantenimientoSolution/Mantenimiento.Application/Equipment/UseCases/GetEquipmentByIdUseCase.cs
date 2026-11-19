namespace Mantenimiento.Application.Equipment.UseCases;

using Mantenimiento.Application.Common.Exceptions;
using Mantenimiento.Application.Equipment.DTOs;
using Mantenimiento.Application.Interfaces;
using Mantenimiento.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public interface IGetEquipmentByIdUseCase
{
    Task<Equipment?> ExecuteAsync(GetEquipmentByIdRequest request, CancellationToken ct = default);
}


public class GetEquipmentByIdUseCase : IGetEquipmentByIdUseCase
{
    private readonly IAppDbContext _context;

    public GetEquipmentByIdUseCase(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Equipment?> ExecuteAsync(GetEquipmentByIdRequest request, CancellationToken ct = default)
    {
        Equipment? equipment = await _context.Equipment.SingleOrDefaultAsync(e => e.Id == request.Id, ct);
        
        if (equipment is null)
        {
            throw new NotFoundException("Equipo", request.Id);
        }

        return equipment;
    }
}
