using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olivia.Primitives;
using Olivia.Repositories;
using Olivia.RepositoryInterfaces;
using Olivia.RepositoryInterfaces.Tenant;

namespace Olivia.Services.TenantDomain;

public sealed class TenantService
{
    private readonly ITenantRepository _tenantRepository;

    public TenantService(ITenantRepository tenantRepository)
    {
        _tenantRepository = tenantRepository;
    }

    public Task<IEnumerable<Tenant>> GetAllTenantsAsync(CancellationToken cancellationToken)
    {
        return _tenantRepository.GetAllAsync(cancellationToken);
    }

    public Task<Tenant> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _tenantRepository.GetByIdAsync(id, cancellationToken);
    }

    public Task<Tenant> CreateTenantAsync(Tenant tenant, CancellationToken cancellationToken)
    {
        return _tenantRepository.CreateAsync(tenant, cancellationToken);
    }

    public Task DeleteTenantByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _tenantRepository.DeleteByIdAsync(id, cancellationToken);
    }

    public Task UpdateTenantByIdAsync(Tenant tenant, CancellationToken cancellationToken)
    {
        return _tenantRepository.UpdateAsync(tenant, cancellationToken);
    }
}
