namespace MantenimientoApi.Controllers;

using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Mantenimiento.Application.Equipment.DTOs;
using Mantenimiento.Application.Equipment.UseCases;
using Mantenimiento.Application.Common.Exceptions;

[ApiController]
[Route("api/[controller]")]
public class EquipmentController : ControllerBase
{
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEquipment(int id, 
        [FromBody] UpdateEquipmentRequest request, 
        [FromServices] IValidator<UpdateEquipmentRequest> validator,
        [FromServices] UpdateEquipmentUseCase useCase,
        CancellationToken ct
    )
    {
        var result = await validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }
        
        try
        {
            var updatedEquipment = await useCase.Handle(request, ct);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }

        return Ok(CreatedAtAction(nameof(UpdateEquipment), new { id = request.Id }, request));
    }
}