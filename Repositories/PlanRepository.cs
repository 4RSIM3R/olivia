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

namespace Olivia.Repositories;

public sealed class PlanRepository : IPlanRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PlanRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Plan> CreateAsync(Plan input, CancellationToken cancellationToken)
    {
        var planEntry = new Entities.Master.Tenant()
        {
            Name = input.Name,
            GracefulPeriodDay = input.GracefulPeriodDay,
            MaxDurationDay = input.MaxDurationDay,
            Price = input.Price,
            MaxVoter = input.MaxVoter,
            MaxCandidate = input.MaxCandidate,
        };
        await _dbContext.Plan.AddAsync(planEntry, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new Plan
        {
            Id = planEntry.Id,
            Name = planEntry.Name,
            Price = planEntry.Price,
            MaxVoter = planEntry.MaxVoter,
            MaxCandidate = planEntry.MaxCandidate,
            MaxDurationDay = planEntry.MaxDurationDay,
            GracefulPeriodDay = planEntry.GracefulPeriodDay,
        };
    }

    public async Task UpdateAsync(Plan input, CancellationToken cancellationToken)
    {
        _dbContext.Entry(input).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
    {
        var plan = await _dbContext.Plan.FindAsync(id, cancellationToken);
        if (plan is null) throw new NotFoundException();
        _dbContext.Plan.Remove(plan);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Plan>> GetAllAsync(CancellationToken cancellationToken)
    {
        var plans = await _dbContext.Plan
            .Select(plan => new
                Plan
            {
                Id = plan.Id,
                Name = plan.Name,
                Price = plan.Price,
                MaxVoter = plan.MaxVoter,
                MaxCandidate = plan.MaxCandidate,
                MaxDurationDay = plan.MaxDurationDay,
                GracefulPeriodDay = plan.GracefulPeriodDay,
            })
            .ToListAsync(cancellationToken);
        return plans ?? Enumerable.Empty<Plan>();
    }

    public async Task<Plan> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var plan = await _dbContext.Plan.FindAsync(id);
        if (plan is null) throw new NotFoundException();
        return new Plan
        {
            Id = plan.Id,
            Name = plan.Name,
            Price = plan.Price,
            MaxVoter = plan.MaxVoter,
            MaxCandidate = plan.MaxCandidate,
            MaxDurationDay = plan.MaxDurationDay,
            GracefulPeriodDay = plan.GracefulPeriodDay,
        };
    }
}