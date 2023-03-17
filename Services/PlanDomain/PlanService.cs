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
}
