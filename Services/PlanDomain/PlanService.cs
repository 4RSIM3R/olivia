using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olivia.Primitives;
using Olivia.RepositoryInterfaces;

namespace Olivia.Services.PlanDomain;

public sealed class PlanService
{
    private readonly IPlanRepository _planRepository;

    public PlanService(IPlanRepository planRepository)
    {
        _planRepository = planRepository;
    }

    public Task<IEnumerable<Plan>> GetAllPlansAsync(CancellationToken cancellationToken)
    {
        return _planRepository.GetAllAsync(cancellationToken);
    }

    public Task<Plan> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _planRepository.GetByIdAsync(id, cancellationToken);
    }

    public Task<Plan> CreatePlanAsync(Plan plan, CancellationToken cancellationToken)
    {
        return _planRepository.CreateAsync(plan, cancellationToken);
    }

    public Task DeletePlanByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _planRepository.DeleteByIdAsync(id, cancellationToken);
    }

    public Task UpdatePlanByIdAsync(Plan plan, CancellationToken cancellationToken)
    {
        return _planRepository.UpdateAsync(plan, cancellationToken);
    }
}
