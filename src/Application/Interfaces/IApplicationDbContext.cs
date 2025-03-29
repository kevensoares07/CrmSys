using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Contact> Contacts { get; set; }
    DbSet<Lead> Leads { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}