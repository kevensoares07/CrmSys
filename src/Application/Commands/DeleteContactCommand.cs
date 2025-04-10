using MediatR;

namespace Application.Commands;

public class DeleteContactCommand : IRequest
{
    public int Id { get; set; }
}