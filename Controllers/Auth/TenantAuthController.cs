using System.Collections.Generic;
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
            var errors = new Dictionary<string, string>();
            result.Errors.ForEach(x => errors.Add(x.PropertyName, x.ErrorMessage));
            return BadRequest(new ResponseBase<Dictionary<string, string>>("validation error", errors));
        }

        return Ok(new ResponseBase<RegisterTenant>("Sccess Register", registerTenant));

    }


}