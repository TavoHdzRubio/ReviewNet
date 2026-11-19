namespace Mantenimiento.Application.Equipment.Validators;

using FluentValidation;
using Mantenimiento.Application.Equipment.DTOs;

public class DeleteEquipmentRequestValidator : AbstractValidator<DeleteEquipmentRequest>
{
    public DeleteEquipmentRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("The Id must be greater than 0.");
    }
}