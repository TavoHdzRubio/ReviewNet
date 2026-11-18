using FluentValidation;
using Mantenimiento.Application.Equipment.DTOs;

namespace Mantenimiento.Application.Equipment.Validators;

public class CreateEquipmentRequestValidator : AbstractValidator<CreateEquipmentRequest>
{
    public CreateEquipmentRequestValidator()
    {
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