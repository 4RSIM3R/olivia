using Olivia.Entites;
using Olivia.RepositoryInterfaces;

namespace Olivia.Repositories;

public class AuthTenantRepository : IAuthTenantRepository
{

    private readonly ApplicationDbContext _dbContext;

    public AuthTenantRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

}