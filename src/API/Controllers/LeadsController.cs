using Application.Commands;
using Application.Queries;
using Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeadsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeadsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateLead([FromBody] CreateLeadCommand command)
    {
        var lead = await _mediator.Send(command);
        return Ok(lead);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLeads([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
    {
        var leads = await _mediator.Send(new GetAllLeadsQuery());
        if (startDate.HasValue && endDate.HasValue)
        {
            leads = leads.Where(l => l.CreatedAt >= startDate.Value && l.CreatedAt <= endDate.Value);
        }
        return Ok(leads);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLead(int id)
    {
        await _mediator.Send(new DeleteLeadCommand { Id = id });
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLead(int id, [FromBody] UpdateLeadCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        var updatedLead = await _mediator.Send(command);
        return Ok(updatedLead);
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetLeadsStats([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var leads = await _mediator.Send(new GetAllLeadsQuery());
        var filteredLeads = leads.Where(l => l.CreatedAt >= startDate && l.CreatedAt <= endDate);
        var stats = new
        {
            TotalLeads = filteredLeads.Count(),
            TotalValue = filteredLeads.Sum(l => l.Value),
            Conversions = filteredLeads.Count(l => l.Status == "Fechado – Ganhou")
        };
        return Ok(stats);
    }
}