namespace Mantenimiento.Application.Equipment.Validators;

using Mantenimiento.Application.Equipment.DTOs;
using FluentValidation;

public class UpdateEquipmentRequestValidator : AbstractValidator<UpdateEquipmentRequest>
{
    public UpdateEquipmentRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El Id del equipo es obligatorio y debe ser mayor a 0.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre del equipo es obligatorio.")
            .MaximumLength(255).WithMessage("El nombre del equipo no puede exceder los 255 caracteres.");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("El código es obligatorio.")
            .MaximumLength(50).WithMessage("El código no puede exceder los 50 caracteres.");

        RuleFor(x => x.Area)
            .NotEmpty().WithMessage("El área es obligatorio.")
            .MaximumLength(100).WithMessage("El área no puede exceder los 100 caracteres.");

        RuleFor(x => x.Active)
            .NotNull().WithMessage("El Activo es obligatorio.");
    }
}