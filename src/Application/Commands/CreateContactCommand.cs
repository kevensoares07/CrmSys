using Application.DTOs;
using MediatR;

namespace Application.Commands;

public class CreateContactCommand : IRequest<ContactDto>
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}