using Application.Commands;
using Application.Queries;
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
        return Ok(await _mediator.Send(command));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllContacts([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
    {
        var contacts = await _mediator.Send(new GetAllContactsQuery());
        if (startDate.HasValue && endDate.HasValue)
        {
            contacts = contacts.Where(c => c.CreatedAt >= startDate.Value && c.CreatedAt <= endDate.Value).ToList();
        }
        return Ok(contacts);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        await _mediator.Send(new DeleteContactCommand { Id = id });
        return NoContent();
    }
}