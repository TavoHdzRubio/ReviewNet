namespace Mantenimiento.Application.Equipment.UseCases;

using Mantenimiento.Application.Common.Exceptions;
using Mantenimiento.Application.Equipment.DTOs;
using Mantenimiento.Application.Interfaces;
using Mantenimiento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;


public class GetEquipmentByIdUseCase : IRequestHandler<GetEquipmentByIdRequest, Equipment?>
{
    private readonly IAppDbContext _context;

    public GetEquipmentByIdUseCase(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Equipment?> Handle(GetEquipmentByIdRequest request, CancellationToken ct = default)
    {
        Equipment? equipment = await _context.Equipment.SingleOrDefaultAsync(e => e.Id == request.Id && e.DeletedAt == null, ct);
        
        if (equipment is null)
        {
            throw new NotFoundException("Equipo", request.Id);
        }

        return equipment;
    }
}
