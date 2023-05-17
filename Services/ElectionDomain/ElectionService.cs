using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olivia.Entites.Master;
using Olivia.Primitives;
using Olivia.Repositories;
using Olivia.RepositoryInterfaces;

namespace Olivia.Services.ElectionDomain;

public sealed class ElectionService
{
    private readonly IElectionRepository _electionRepository;

    public ElectionService(IElectionRepository electionRepository)
    {
        _electionRepository = electionRepository;
    }

    public Task<IEnumerable<Election>> GetAllElectionsAsync(CancellationToken cancellationToken)
    {
        return _electionRepository.GetAllAsync(cancellationToken);
    }

    public Task<Election> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _electionRepository.GetByIdAsync(id, cancellationToken);
    }
    public Task<Election> CreateElectionAsync(Election election, CancellationToken cancellationToken)
    {
        return _electionRepository.CreateAsync(election, cancellationToken);
    }
    public Task DeleteElectionByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _electionRepository.DeleteByIdAsync(id, cancellationToken);
    }
    public Task UpdateElectionByIdAsync(Election election, CancellationToken cancellationToken)
    {
        return _electionRepository.UpdateAsync(election, cancellationToken);
    }
}
       