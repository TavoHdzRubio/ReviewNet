namespace Mantenimiento.Application.Equipment.UseCases;

using Mantenimiento.Application.Common.Exceptions;
using Mantenimiento.Application.Equipment.DTOs;
using Mantenimiento.Application.Interfaces;
using Mantenimiento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

public class UpdateEquipmentUseCase : IRequestHandler<UpdateEquipmentRequest, int?>
{
    private readonly IAppDbContext _context;

    public UpdateEquipmentUseCase(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int?> Handle(UpdateEquipmentRequest request, CancellationToken ct = default)
    {
        Equipment? equipment = await _context.Equipment.SingleOrDefaultAsync(e => e.Id == request.Id, ct);
        
        if (equipment is null)
        {
            throw new NotFoundException("Equipo", request.Id);
        }

        equipment.Area = request.Area;
        equipment.Code = request.Code;
        equipment.Name = request.Name;
        equipment.Active = request.Active;
        equipment.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync(ct);

        return equipment.Id;
    }

}