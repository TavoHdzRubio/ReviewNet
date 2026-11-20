namespace Mantenimiento.Application.Equipment.UseCases;

using Mantenimiento.Application.Common.Exceptions;
using Mantenimiento.Application.Equipment.DTOs;
using Mantenimiento.Application.Interfaces;
using Mantenimiento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;


public class DeleteEquipmentUseCase : IRequestHandler<DeleteEquipmentRequest, Equipment?>
{
    private readonly IAppDbContext _context;

    public DeleteEquipmentUseCase(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Equipment?> Handle(DeleteEquipmentRequest request, CancellationToken ct = default)
    {
        Equipment? equipment = await _context.Equipment.SingleOrDefaultAsync(e => e.Id == request.Id && e.DeletedAt == null, ct);
        
        if (equipment is null)
        {
            throw new NotFoundException("Equipo", request.Id);
        }

        equipment.DeletedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync(ct);

        return equipment;
    }
}
