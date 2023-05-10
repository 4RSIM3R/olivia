using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Olivia.DTOs;
using Olivia.Primitives;
using Olivia.Repositories.Exceptions;
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
        var plans = await _planService.GetAllPlansAsync(cancellationToken);
        return Ok(new GetPlansResponse(
            Message: "Success",
            Data: plans.Select(plan => new PlanDto
            {
                Id = plan.Id,
                Name = plan.Name,
                Price = plan.Price,
                MaxCandidate = plan.MaxCandidate,
                MaxVoter = plan.MaxVoter,
                GracefulPeriodDay = plan.GracefulPeriodDay,
                MaxDurationDay = plan.MaxDurationDay
            })
        ));
    }

    [HttpGet]
    [Route(":id")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var plan = await _planService.GetByIdAsync(id, cancellationToken);
            return Ok(new GetPlanByIdResponse(
                Message: "Success",
                Data: new PlanDto
                {
                    Id = plan.Id,
                    Name = plan.Name,
                    Price = plan.Price,
                    MaxCandidate = plan.MaxCandidate,
                    MaxVoter = plan.MaxVoter,
                    GracefulPeriodDay = plan.GracefulPeriodDay,
                    MaxDurationDay = plan.MaxDurationDay
                }
            ));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PlanDto input, CancellationToken cancellationToken)
    {
        var plan = await _planService.CreatePlanAsync(new Plan
        {
            Name = input.Name,
            Price = input.Price,
            MaxCandidate = input.MaxCandidate,
            MaxVoter = input.MaxVoter,
            GracefulPeriodDay = input.GracefulPeriodDay,
            MaxDurationDay = input.MaxDurationDay
        }, cancellationToken);
        return CreatedAtAction(nameof(GetById), plan.Id);
    }

    [HttpPut]
    [Route(":id")]
    public async Task<IActionResult> UpdatePlan(int id, [FromBody] PlanDto input, CancellationToken cancellationToken)
    {
        await _planService.UpdatePlanByIdAsync(new Plan
        {
            Id = input.Id,
            Name = input.Name,
            Price = input.Price,
            MaxCandidate = input.MaxCandidate,
            MaxVoter = input.MaxVoter,
            GracefulPeriodDay = input.GracefulPeriodDay,
            MaxDurationDay = input.MaxDurationDay
        }, cancellationToken);
        return Ok(new
        {
            Message = $"Updated Plan with an ID of {id}"
        });
    }

    [HttpDelete]
    [Route(":id")]
    public async Task<IActionResult> DeletePlan(int id, CancellationToken cancellationToken)
    {
        await _planService.DeletePlanByIdAsync(id, cancellationToken);
        return Ok(new
        {
            Message = $"Deleted Plan with an ID of {id}"
        });
    }
}