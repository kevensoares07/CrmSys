using Application.Commands;
using Application.Queries;
using Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact([FromBody] CreateContactCommand command)
    {
        if (command == null)
        {
            return BadRequest("Dados do contato não fornecidos.");
        }

        try
        {
            var contact = await _mediator.Send(command);
            return Ok(contact);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao criar contato: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllContacts([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
    {
        try
        {
            var query = new GetAllContactsQuery();
            var contacts = await _mediator.Send(query);

            if (startDate.HasValue && endDate.HasValue)
            {
                if (startDate > endDate)
                {
                    return BadRequest("A data de início não pode ser maior que a data de fim.");
                }

                contacts = contacts.Where(c => c.CreatedAt >= startDate.Value && c.CreatedAt <= endDate.Value).ToList();
            }

            return Ok(contacts);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao buscar contatos: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        try
        {
            var command = new DeleteContactCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao deletar contato: {ex.Message}");
        }
    }
}