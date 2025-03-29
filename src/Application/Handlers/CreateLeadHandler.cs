using Application.Commands;
using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers;

public class CreateLeadHandler : IRequestHandler<CreateLeadCommand, LeadDto>
{
    private readonly ILeadRepository _leadRepository;

    public CreateLeadHandler(ILeadRepository leadRepository)
    {
        _leadRepository = leadRepository;
    }

    public async Task<LeadDto> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Name) || request.Value <= 0)
            throw new ArgumentException("Nome e valor são obrigatórios.");

        var lead = new Lead
        {
            Name = request.Name,
            Value = request.Value,
            Channel = request.Channel,
            Product = request.Product,
            Urgency = request.Urgency,
            Status = request.Status ?? "Prospecção"
        };

        var createdLead = await _leadRepository.AddAsync(lead);
        return new LeadDto
        {
            Id = createdLead.Id,
            Name = createdLead.Name,
            Value = createdLead.Value,
            Channel = createdLead.Channel,
            Product = createdLead.Product,
            Urgency = createdLead.Urgency,
            Status = createdLead.Status,
            Followup = createdLead.Followup,
            PurchaseProduct = createdLead.PurchaseProduct,
            Payment = createdLead.Payment,
            PurchaseReason = createdLead.PurchaseReason,
            NoPurchaseReason = createdLead.NoPurchaseReason,
            Messages = createdLead.Messages
        };
    }
}