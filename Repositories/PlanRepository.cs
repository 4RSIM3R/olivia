using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olivia.Entites;
using Olivia.Primitives;
using Olivia.RepositoryInterfaces;

namespace Olivia.Repositories;

public sealed class PlanRepository : IPlanRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PlanRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task CreateAsync(Plan input, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Plan>> GetAllAsync(CancellationToken cancellationToken)
    {
        IEnumerable<Plan> plans = await _dbContext.Plan.Select(plan => new Plan(plan.Id, plan.Name)).ToListAsync();
        return plans;
    }

    public Task<Plan> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
