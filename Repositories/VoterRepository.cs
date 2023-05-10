using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olivia.Entites;
using Olivia.Entities;
using Olivia.Primitives;
using Olivia.Repositories.Exceptions;
using Olivia.RepositoryInterfaces;

namespace Olivia.Repositories;

public class VoterRepository : IVoterRepository
{
    private readonly ApplicationDbContext _dbContext;

    public VoterRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Voter> CreateAsync(Voter input, CancellationToken cancellationToken)
    {
        var voterEntry = new Entites.Master.Voter()
        {
            SIN = input.SIN,
            Name = input.Name,
            Email = input.Email,
            Password = input.Password,
            Phone = input.Phone,    
            Address = input.Address,
            Major = input.Major,
            Tenants = input.Tenants,
        };
        await _dbContext.Voter.AddAsync(voterEntry, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new Voter
        {
            SIN = voterEntry.SIN,
            Name = voterEntry.Name,
            Email = voterEntry.Email,
            Password = voterEntry.Password,
            Phone = voterEntry.Phone,
            Address = voterEntry.Address,
            Major = voterEntry.Major,
            Tenants = voterEntry.Tenants,
        };
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
    {
        var voter = await _dbContext.Plan.FindAsync(id, cancellationToken);
        if (voter is null) throw new NotFoundException();
        _dbContext.Plan.Remove(voter);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Voter>> GetAllAsync(CancellationToken cancellationToken)
    {
        var voters = await _dbContext.Voter
            .Select(voter => new
                Voter
            {
                SIN= voter.SIN,
                Name = voter.Name,
                Email = voter.Email,
                Password = voter.Password,
                Phone = voter.Phone,
                Address = voter.Address,
                Major = voter.Major,
                Tenants = voter.Tenants,    
            })
            .ToListAsync(cancellationToken);
        return voters ?? Enumerable.Empty<Voter>();
    }

    public async Task<Voter> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var voter = await _dbContext.Plan.FindAsync(id);
        if (voter is null) throw new NotFoundException();
        return new Voter
        {
            SIN = voter.SIN,
            Name = voter.Name,
            Email = voter.Email,
            Password = voter.Password,
            Phone = voter.Phone,
            Address = voter.Address,
            Major = voter.Major,
            Tenants = voter.Tenants,
        };
    }

    public async Task UpdateAsync(Voter input, CancellationToken cancellationToken)
    {
        _dbContext.Entry(input).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}

