using Application.Commands;
using Application.DTOs;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers;

public class UpdateLeadHandler : IRequestHandler<UpdateLeadCommand, LeadDto>
{
    private readonly ILeadRepository _leadRepository;

    public UpdateLeadHandler(ILeadRepository leadRepository)
    {
        _leadRepository = leadRepository;
    }

    public async Task<LeadDto> Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = await _leadRepository.GetByIdAsync(request.Id); // Assumindo que adicionamos esse método
        if (lead == null) throw new Exception("Lead não encontrado");

        lead.Name = request.Name;
        lead.Status = request.Status;
        lead.Value = request.Value;

        await _leadRepository.UpdateAsync(lead); // Assumindo que adicionamos esse método
        return new LeadDto
        {
            Id = lead.Id,
            Name = lead.Name,
            Status = lead.Status,
            Value = lead.Value
        };
    }
}