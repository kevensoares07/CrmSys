using Application.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers;

public class DeleteLeadHandler : IRequestHandler<DeleteLeadCommand, Unit>
{
    private readonly ILeadRepository _leadRepository;

    public DeleteLeadHandler(ILeadRepository leadRepository)
    {
        _leadRepository = leadRepository;
    }

    public async Task<Unit> Handle(DeleteLeadCommand request, CancellationToken cancellationToken)
    {
        await _leadRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}