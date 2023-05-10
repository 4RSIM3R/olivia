using Olivia.Repositories;

namespace Olivia.Services.AuthDomain;

public class AuthTenantService
{

    AuthTenantRepository _repository;

    public AuthTenantService(AuthTenantRepository planRepository)
    {
        _repository = planRepository;
    }

    

}