using Olivia.Entites.Master;
using Olivia.Repositories.Interfaces;

namespace Olivia.Repositories;

public sealed class PlanRepository : IRepository<Plan>
{
    public Task CreateAsync(Plan input, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Plan>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Plan> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
