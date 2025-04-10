using Domain.Interfaces;
using MediatR;

namespace Application.Commands.Handlers
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Unit>
    {
        private readonly IContactRepository _contactRepository;

        public DeleteContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetByIdAsync(request.Id);
            if (contact == null)
            {
                throw new KeyNotFoundException("Contato não encontrado.");
            }

            await _contactRepository.DeleteAsync(contact);
    
            return Unit.Value;
        }

    }
}