namespace Mantenimiento.Application.Equipment.Validators;

using FluentValidation;
using Mantenimiento.Application.Equipment.DTOs;

public class GetEquipmentByIdRequestValidator : AbstractValidator<GetEquipmentByIdRequest>
{
    public GetEquipmentByIdRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El Id del equipo debe ser mayor que cero.");
    }
}