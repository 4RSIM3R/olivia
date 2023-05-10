using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olivia.Primitives;
using Olivia.RepositoryInterfaces;

namespace Olivia.Services.VoterDomain
{
    public class VoterService
    {
        private readonly IVoterRepository _voterRepository;

        public VoterService(IVoterRepository voterRepository)
        {
            _voterRepository = voterRepository;
        }

        public Task<IEnumerable<Voter>> GetAllVotersAsync(CancellationToken cancellationToken)
    {
        return _voterRepository.GetAllAsync(cancellationToken);
    }

        public Task<Voter> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return _voterRepository.GetByIdAsync(id, cancellationToken);
        }

        public Task<Voter> CreateVoterAsync(Voter Voter, CancellationToken cancellationToken)
        {
            return _voterRepository.CreateAsync(Voter, cancellationToken);
        }

        public Task DeleteVoterByIdAsync(int id, CancellationToken cancellationToken)
        {
            return _voterRepository.DeleteByIdAsync(id, cancellationToken);
        }

        public Task UpdateVoterByIdAsync(Voter Voter, CancellationToken cancellationToken)
        {
            return _voterRepository.UpdateAsync(Voter, cancellationToken);
        }
    }
}
