using Application.Commands;
using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers;

public class CreateContactHandler : IRequestHandler<CreateContactCommand, ContactDto>
{
    private readonly IContactRepository _contactRepository;

    public CreateContactHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<ContactDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact
        {
            Name = request.Name,
            Email = request.Email,
            Phone = request.Phone
        };

        var createdContact = await _contactRepository.AddAsync(contact);
        return new ContactDto
        {
            Id = createdContact.Id,
            Name = createdContact.Name,
            Email = createdContact.Email,
            Phone = createdContact.Phone
        };
    }
}