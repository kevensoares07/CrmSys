using Application.DTOs;
using MediatR;

namespace Application.Queries;

public class GetAllLeadsQuery : IRequest<IEnumerable<LeadDto>>
{
}