using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Olivia.DTOs;

namespace Olivia.Controllers;

[ApiController]
[Route("[controller]")]
public class TenantAuthController : ControllerBase
{

    public IValidator<RegisterTenant> _registerTenantValidator;

    public TenantAuthController(IValidator<RegisterTenant> registerTenantValidator)
    {
        this._registerTenantValidator = registerTenantValidator;
    }

    [HttpPost]
    public IActionResult Register([FromBody] RegisterTenant registerTenant)
    {

        // Call Validate or ValidateAsync and pass the object which needs to be validated
        var result = _registerTenantValidator.Validate(registerTenant);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        return Ok(new ResponseBase<RegisterTenant>("Sccess Register", registerTenant));

    }


}