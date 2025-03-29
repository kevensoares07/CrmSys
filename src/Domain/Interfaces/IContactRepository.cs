using Domain.Entities;

namespace Domain.Interfaces;

public interface IContactRepository
{
    Task<Contact> AddAsync(Contact contact);
    Task<IEnumerable<Contact>> GetAllAsync();
}