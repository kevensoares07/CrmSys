// Infrastructure/Repositories/LeadRepository.cs
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class LeadRepository : ILeadRepository
{
    private readonly ApplicationDbContext _context;

    public LeadRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Lead> AddAsync(Lead lead)
    {
        _context.Leads.Add(lead);
        await _context.SaveChangesAsync(CancellationToken.None);
        return lead;
    }

    public async Task<IEnumerable<Lead>> GetAllAsync()
    {
        return await _context.Leads.ToListAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var lead = await _context.Leads.FindAsync(id);
        if (lead != null)
        {
            _context.Leads.Remove(lead);
            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }

    public async Task<Lead> GetByIdAsync(int id)
    {
        return await _context.Leads.FindAsync(id);
    }

    public async Task<Lead> UpdateAsync(Lead lead) 
    {
        _context.Leads.Update(lead);
        await _context.SaveChangesAsync(CancellationToken.None);
        return lead;
    }
}