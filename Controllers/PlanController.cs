using Microsoft.AspNetCore.Mvc;

namespace Olivia.Controllers;

[ApiController]
[Route("[controller]")]

public sealed class PlanController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Create()
    {
        return CreatedAtAction(nameof(Create), null);
    }
}
