namespace Mantenimiento.Application.Equipment.UseCases;

using Mantenimiento.Application.Equipment.DTOs;
using Mantenimiento.Application.Interfaces;
using Mantenimiento.Domain.Entities;

public interface ICreateEquipmentUseCase
{
    Task<int> ExecuteAsync(CreateEquipmentRequest request, CancellationToken ct = default);
}

public class CreateEquipmentUseCase : ICreateEquipmentUseCase
{
    private readonly IAppDbContext _context;

    public CreateEquipmentUseCase(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> ExecuteAsync(CreateEquipmentRequest request, CancellationToken ct = default)
    {
        var equipment = new Equipment
        {
            Code = request.Code,
            Name = request.Name,
            Area = request.Area,
            Active = request.Active
        };

        _context.Equipment.Add(equipment);
        await _context.SaveChangesAsync(ct);

        return equipment.Id;
    }
}