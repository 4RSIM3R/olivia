using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Olivia.DTOs;
using Olivia.Primitives;
using Olivia.Repositories.Exceptions;
using Olivia.Services.PlanDomain;
using Olivia.Services.VoterDomain;

namespace Olivia.Controllers;

[ApiController]
[Route("[controller]")]

public sealed class VoterController : ControllerBase
{
    private readonly VoterService _voterService;

    public VoterController(VoterService voterService)
    {
        _voterService = voterService;
    }

    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var voters = await _voterService.GetAllVotersAsync(cancellationToken);
        return Ok(new GetVotersResponse(
            Message: "Success",
            Data: voters.Select(voter => new VoterDto
            {
                SIN = voter.SIN,
                Name = voter.Name,
                Email = voter.Email,
                Password = voter.Password,
                Phone = voter.Phone,
                Address = voter.Address,
                Major = voter.Major,
                Tenants = voter.Tenants,
            })
        ));
    }

    [HttpGet]
    [Route(":id")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var voter = await _voterService.GetByIdAsync(id, cancellationToken);
            return Ok(new GetVoterByIdResponse(
                Message: "Success",
                Data: new VoterDto
                {
                    SIN = voter.SIN,
                    Name = voter.Name,
                    Email = voter.Email,
                    Password = voter.Password,
                    Phone = voter.Phone,
                    Address = voter.Address,
                    Major = voter.Major,
                    Tenants = voter.Tenants,
                }
            ));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VoterDto input, CancellationToken cancellationToken)
    {
        var voter = await _voterService.CreateVoterAsync(new Voter
        {
            SIN = input.SIN,
            Name = input.Name,
            Email = input.Email,
            Password = input.Password,
            Phone = input.Phone,
            Address = input.Address,
            Major = input.Major,
            Tenants = input.Tenants,
        }, cancellationToken);
        return CreatedAtAction(nameof(GetById), voter.Id);
    }

    [HttpPut]
    [Route(":id")]
    public async Task<IActionResult> UpdateVoter(int id, [FromBody] VoterDto input, CancellationToken cancellationToken)
    {
        await _voterService.UpdateVoterByIdAsync(new Voter
        {
            SIN = input.SIN,
            Name = input.Name,
            Email = input.Email,
            Password = input.Password,
            Phone = input.Phone,
            Address = input.Address,
            Major = input.Major,
            Tenants = input.Tenants,
        }, cancellationToken);
        return Ok(new
        {
            Message = $"Updated Voter with an ID of {id}"
        });
    }

    [HttpDelete]
    [Route(":id")]
    public async Task<IActionResult> DeleteVoter(int id, CancellationToken cancellationToken)
    {
        await _voterService.DeleteVoterByIdAsync(id, cancellationToken);
        return Ok(new
        {
            Message = $"Deleted Voter with an ID of {id}"
        });
    }
}
