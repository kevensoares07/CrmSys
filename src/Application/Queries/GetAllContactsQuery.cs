using Application.DTOs;
using MediatR;

namespace Application.Queries;

public class GetAllContactsQuery : IRequest<IEnumerable<ContactDto>>
{
}