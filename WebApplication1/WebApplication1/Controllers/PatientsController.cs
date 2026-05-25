using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientsController(IPatientsService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllResponse([FromQuery] string? search, CancellationToken cancellationToken)
    {
        return Ok(await service.GetAllPatientsAsync(search, cancellationToken));
    }
}