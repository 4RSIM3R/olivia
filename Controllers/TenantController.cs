using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Olivia.DTOs;
using Olivia.Primitives;
using Olivia.Repositories.Exceptions;
using Olivia.Services.PlanDomain;
using Olivia.Services.TenantDomain;

namespace Olivia.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TenantController : ControllerBase
{
    private readonly TenantService _tenantService;

    public TenantController(TenantService tenantService)
    {
        _tenantService = tenantService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var tenants = await _tenantService.GetAllTenantsAsync(cancellationToken);
        return Ok(new GetTenantsResponse(
            Message: "Success",
            Data: tenants.Select(tenant => new TenantDto
            {
                Id = tenant.Id,
                Name = tenant.Name,
                Email = tenant.Email,
                Password = tenant.Password,
                Voters = tenant.Voters,
            })
        ));
    }

    [HttpGet]
    [Route(":id")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var tenant = await _tenantService.GetByIdAsync(id, cancellationToken);
            return Ok(new GetTenantByIdResponse(
                Message: "Success",
                Data: new TenantDto
                {
                    Id = tenant.Id,
                    Name = tenant.Name,
                    Email = tenant.Email,
                    Password = tenant.Password,
                    Voters = tenant.Voters,
                }
            ));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TenantDto input, CancellationToken cancellationToken)
    {
        var tenant = await _tenantService.CreateTenantAsync(new Tenant
        {
            Name = input.Name,
            Email = input.Email,
            Password = input.Password,
            Voters = input.Voters,
        }, cancellationToken);
        return CreatedAtAction(nameof(GetById), tenant.Id);
    }

    [HttpPut]
    [Route(":id")]
    public async Task<IActionResult> UpdateTenant(int id, [FromBody] TenantDto input, CancellationToken cancellationToken)
    {
        await _tenantService.UpdatePlanByIdAsync(new Tenant
        {
            Name = input.Name,
            Email = input.Email,
            Password = input.Password,
            Voters = input.Voters,
        }, cancellationToken);
        return Ok(new
        {
            Message = $"Updated Tenant with an ID of {id}"
        });
    }

    [HttpDelete]
    [Route(":id")]
    public async Task<IActionResult> DeleteTenant(int id, CancellationToken cancellationToken)
    {
        await _tenantService.DeleteTenantByIdAsync(id, cancellationToken);
        return Ok(new
        {
            Message = $"Deleted Tenant with an ID of {id}"
        });
    }

}
