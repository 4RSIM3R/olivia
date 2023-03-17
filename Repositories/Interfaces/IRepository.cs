namespace Olivia.Repositories.Interfaces;

public interface IRepository<TData> {
    public Task<IEnumerable<TData>> GetAllAsync(CancellationToken cancellationToken);
    public Task<TData> GetByIdAsync(int id, CancellationToken cancellationToken);
    public Task CreateAsync(TData input, CancellationToken cancellationToken);
    public Task DeleteById(int id, CancellationToken cancellationToken);
}
