using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Olivia.DTOs;
using Olivia.Primitives;
using Olivia.Services.PlanDomain;

namespace Olivia.Controllers;

[ApiController]
[Route("[controller]")]

public sealed class PlanController : ControllerBase
{
    private readonly PlanService _planService;

    public PlanController(PlanService planService)
    {
        _planService = planService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        IEnumerable<Plan> plans = await _planService.GetAllPlansAsync(cancellationToken);
        return Ok(new GetPlansResponse(
            Message: "Success",
            Data: plans.Select(plan => new PlanDTO(plan.Id, plan.Name))
        ));
    }

    [HttpGet]
    [Route(":id")]
    public IActionResult GetById(int Id)
    {
        // TODO: implement properly
        return Ok(new GetPlanByIdResponse(
            Message: "Success",
            Data: new PlanDTO(Id: 1, Name: "Example Plan")
        ));
    }

    [HttpPost]
    public IActionResult Create()
    {
        // TODO: implement properly
        return CreatedAtAction(nameof(GetById), null);
    }
}
