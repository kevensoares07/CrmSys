using Application.DTOs;
using Application.Queries;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers;

public class GetAllLeadsHandler : IRequestHandler<GetAllLeadsQuery, IEnumerable<LeadDto>>
{
    private readonly ILeadRepository _leadRepository;

    public GetAllLeadsHandler(ILeadRepository leadRepository)
    {
        _leadRepository = leadRepository;
    }

    public async Task<IEnumerable<LeadDto>> Handle(GetAllLeadsQuery request, CancellationToken cancellationToken)
    {
        var leads = await _leadRepository.GetAllAsync();
        return leads.Select(l => new LeadDto
        {
            Id = l.Id,
            Name = l.Name,
            Status = l.Status,
            Value = l.Value,
            Channel = l.Channel 
        });
    }
}