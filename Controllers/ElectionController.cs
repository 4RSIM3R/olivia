using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Olivia.DTOs;
using Olivia.Entites.Master;
using Olivia.Primitives;
using Olivia.Repositories.Exceptions;
using Olivia.Services.ElectionDomain;
using Olivia.Services.PlanDomain;

namespace Olivia.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ElectionController : ControllerBase
{
    private readonly ElectionService _electionService;

    public ElectionController(ElectionService electionService)
    {
        _electionService = electionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var elections = await _electionService.GetAllElectionsAsync(cancellationToken);
        return Ok(new GetElectionsResponse(
            Message: "Success",
            Data: elections.Select(election => new ElectionDto
            {
                Id = election.Id,
                StartAt = election.StartAt,
                EndAt = election.EndAt,
               
            })
        ));
    }

    [HttpGet]
    [Route(":id")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var election = await _electionService.GetByIdAsync(id, cancellationToken);
            return Ok(new GetElectionByIdResponse(
                Message: "Success",
                Data: new ElectionDto
                {
                    Id = election.Id,
                    StartAt = election.StartAt,
                    EndAt = election.EndAt,
                }
            ));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ElectionDto input, CancellationToken cancellationToken)
    {
        var election = await _electionService.CreateElectionAsync(new Election
        {
            //Tenant = input.Tenant,
            //Candidates = input.Candidates,
            StartAt = input.StartAt,
            EndAt = input.EndAt,
        }, cancellationToken);
        return CreatedAtAction(nameof(GetById), election.Id);
    }

    [HttpPut]
    [Route(":id")]
    public async Task<IActionResult> UpdateElection(int id, [FromBody] ElectionDto input, CancellationToken cancellationToken)
    {
        await _electionService.UpdateElectionByIdAsync(new Election
        {
            Id = input.Id,
            StartAt = input.StartAt,
            EndAt = input.EndAt,
        }, cancellationToken);
        return Ok(new
        {
            Message = $"Updated Plan with an ID of {id}"
        });
    }

    [HttpDelete]
    [Route(":id")]
    public async Task<IActionResult> DeleteElection(int id, CancellationToken cancellationToken)
    {
        await _electionService.DeleteElectionByIdAsync(id, cancellationToken);
        return Ok(new
        {
            Message = $"Deleted Plan with an ID of {id}"
        });
    }
}