using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olivia.Entites;
using Olivia.Primitives;
using Olivia.Repositories.Exceptions;
using Olivia.RepositoryInterfaces;
using Olivia.RepositoryInterfaces.Tenant;

namespace Olivia.Repositories;

public sealed class TenantRepository : ITenantRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TenantRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Tenant> CreateAsync(Tenant input, CancellationToken cancellationToken)
    {
        var tenantEntry = new Entites.Master.Tenant()
        {
            Name = input.Name,
            Email = input.Email,
            Password = input.Password,
            Voters = input.Voters,
        };
        await _dbContext.Tenant.AddAsync(tenantEntry, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new Tenant
        {
            Id = tenantEntry.Id,
            Name = tenantEntry.Name,
            Email = tenantEntry.Email,
            Password = tenantEntry.Password,
            Voters = tenantEntry.Voters,
        };
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
    {
        var tenant = await _dbContext.Tenant.FindAsync(id, cancellationToken);
        if (tenant is null) throw new NotFoundException();
        _dbContext.Tenant.Remove(tenant);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Tenant>> GetAllAsync(CancellationToken cancellationToken)
    {
        var tenants = await _dbContext.Tenant
        .Select(tenant
        => new
            Tenant
        {
            Id = tenant.Id,
            Name = tenant.Name,
            Email = tenant.Email,
            Password = tenant.Password,
            Voters = tenant.Voters,
        })
        .ToListAsync(cancellationToken);
        return tenants ?? Enumerable.Empty<Tenant>();
    }

    public async Task<Tenant> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var tenant = await _dbContext.Tenant.FindAsync(id);
        if (tenant is null) throw new NotFoundException();
        return new Tenant
        {
            Id = tenant.Id,
            Name = tenant.Name,
            Email = tenant.Email,
            Password = tenant.Password,
            Voters = tenant.Voters
        };
    }

    public async Task UpdateAsync(Tenant input, CancellationToken cancellationToken)
    {
        _dbContext.Entry(input).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
