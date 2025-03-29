using Domain.Entities;

namespace Domain.Interfaces;

public interface ILeadRepository
{
    Task<Lead> AddAsync(Lead lead);
    Task<IEnumerable<Lead>> GetAllAsync();
    Task DeleteAsync(int id);

    Task<Lead> GetByIdAsync(int requestId);
    Task<Lead> UpdateAsync(Lead lead);
}