namespace Mantenimiento.Application.Equipment.UseCases;

using Mantenimiento.Application.Common.Exceptions;
using Mantenimiento.Application.Equipment.DTOs;
using Mantenimiento.Application.Interfaces;
using Mantenimiento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;


public class GetEquipmentsUseCase : IRequestHandler<GetEquipmentsRequest, IEnumerable<EquipmentResponse>>
{
    private readonly IAppDbContext _context;

    public GetEquipmentsUseCase(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EquipmentResponse>> Handle(GetEquipmentsRequest request, CancellationToken ct = default)
    {
        var query = _context.Equipment.AsQueryable();

        if (!string.IsNullOrEmpty(request.Code))
        {
            query = query.Where(e => e.Code.Contains(request.Code));
        }

        if (!string.IsNullOrEmpty(request.Name))
        {
            query = query.Where(e => e.Name.Contains(request.Name));
        }

        if (!string.IsNullOrEmpty(request.Area))
        {
            query = query.Where(e => e.Area.Contains(request.Area));
        }

        if (request.Active.HasValue)
        {
            query = query.Where(e => e.Active == request.Active.Value);
        }

        // Exlude deleted equipment
        query = query.Where(e => e.DeletedAt == null);

        if (request.PageNumber.HasValue && request.PageSize.HasValue)
        {
            int skip = (request.PageNumber.Value - 1) * request.PageSize.Value;
            query = query.Skip(skip).Take(request.PageSize.Value);
        }

        var equipmentList = await query.ToListAsync(ct);
        return equipmentList.Select(e => new EquipmentResponse(
            e.Id,
            e.Code,
            e.Name,
            e.Area,
            e.Active,
            e.UpdatedAt
        ));
    }
}