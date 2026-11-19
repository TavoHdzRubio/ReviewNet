namespace Mantenimiento.Application.Equipment.Validators;

using FluentValidation;
using Mantenimiento.Application.Equipment.DTOs;

public class GetEquipmentsRequestValidator : AbstractValidator<GetEquipmentsRequest>
{
    public GetEquipmentsRequestValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0).WithMessage("El número de página debe ser mayor que cero.")
            .When(x => x.PageNumber.HasValue);

        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("El tamaño de página debe ser mayor que cero.")
            .When(x => x.PageSize.HasValue);
    }
}