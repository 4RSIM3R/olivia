using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olivia.Entites;
using Olivia.Entites.Master;
using Olivia.Primitives;
using Olivia.Repositories.Exceptions;
using Olivia.RepositoryInterfaces;

namespace Olivia.Repositories;


public sealed class ElectionRepository : IElectionRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ElectionRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Election> CreateAsync(Election input, CancellationToken cancellationToken)
    {
        var electionEntry = new Entites.Master.Election()
        {
            Tenant = input.Tenant,
            Candidates = input.Candidates,
            StartAt = input.StartAt,
            EndAt = input.EndAt,
           
        };
        await _dbContext.Election.AddAsync(electionEntry, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new Election
        {
            Id = electionEntry.Id,
            Candidates = electionEntry.Candidates,
            StartAt = electionEntry.StartAt,
            EndAt = electionEntry.EndAt,
            Tenant = input.Tenant,
        };
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
    {
        var election = await _dbContext.Election.FindAsync(id, cancellationToken);
        if (election is null) throw new NotFoundException();
        _dbContext.Election.Remove(election);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Election>> GetAllAsync(CancellationToken cancellationToken)
    {
        var election = await _dbContext.Election
            .Select(election => new
                Election
            {
                Id = election.Id,
                Candidates = election.Candidates,
                StartAt = election.StartAt,
                EndAt = election.EndAt,
                Tenant = election.Tenant,
            })
            .ToListAsync(cancellationToken);
        return election ?? Enumerable.Empty<Election>();
    }

    public async Task<Election> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var election = await _dbContext.Election.FindAsync(id);
        if (election is null) throw new NotFoundException();
        return new Election
        {
            Id = election.Id,
            Candidates = election.Candidates,
            StartAt = election.StartAt,
            EndAt = election.EndAt,
            Tenant = election.Tenant,
        };
    }

    public async Task UpdateAsync(Election input, CancellationToken cancellationToken)
    {
        _dbContext.Entry(input).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
