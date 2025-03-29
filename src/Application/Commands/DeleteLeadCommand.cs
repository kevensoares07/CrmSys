using MediatR;

namespace Application.Commands;

public class DeleteLeadCommand : IRequest<Unit>
{
    public int Id { get; set; }
}