using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Olivia.RepositoryInterfaces;

public interface IRepository<TData>
    where TData : class
{
    public Task<IEnumerable<TData>> GetAllAsync(CancellationToken cancellationToken);
    public Task<TData> GetByIdAsync(int id, CancellationToken cancellationToken);
    public Task CreateAsync(TData input, CancellationToken cancellationToken);
    public Task DeleteByIdAsync(int id, CancellationToken cancellationToken);
}
