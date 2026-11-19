namespace Mantenimiento.Application.Equipment.UseCases;

using Mantenimiento.Application.Common.Exceptions;
using Mantenimiento.Application.Equipment.DTOs;
using Mantenimiento.Application.Interfaces;
using Mantenimiento.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public interface IDeleteEquipmentUseCase
{
    Task<Equipment?> ExecuteAsync(DeleteEquipmentRequest request, CancellationToken ct = default);
}

public class DeleteEquipmentUseCase : IDeleteEquipmentUseCase
{
    private readonly IAppDbContext _context;

    public DeleteEquipmentUseCase(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Equipment?> ExecuteAsync(DeleteEquipmentRequest request, CancellationToken ct = default)
    {
        Equipment? equipment = await _context.Equipment.SingleOrDefaultAsync(e => e.Id == request.Id, ct);
        
        if (equipment is null)
        {
            throw new NotFoundException("Equipo", request.Id);
        }

        equipment.deletionDate = DateTime.UtcNow;
        await _context.SaveChangesAsync(ct);

        return equipment;
    }
}
