// Application/Commands/CreateLeadCommand.cs
using Application.DTOs;
using MediatR;

namespace Application.Commands;

public class CreateLeadCommand : IRequest<LeadDto>
{
    public string Name { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public string Channel { get; set; } = string.Empty;
    public string Product { get; set; } = string.Empty;
    public string Urgency { get; set; } = string.Empty;
    public string Status { get; set; } = "Prospecção"; 
}