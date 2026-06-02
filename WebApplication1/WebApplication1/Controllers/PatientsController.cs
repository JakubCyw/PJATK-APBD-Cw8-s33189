using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
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

    [HttpPost("{pesel}/bedassignments")]
    public async Task<IActionResult> CreateBedAssignment([FromRoute] string pesel,
        [FromBody] BedAssignmentRequest request, CancellationToken cancellationToken)
    {
        var result = await service.AssignBedAsync(pesel, request, cancellationToken);
        return result switch
        {
            Microsoft.AspNetCore.Http.HttpResults.NotFound<object> nf => NotFound(nf.Value),
            Microsoft.AspNetCore.Http.HttpResults.BadRequest<object> br => BadRequest(br.Value),
            Microsoft.AspNetCore.Http.HttpResults.Ok<object> ok => Ok(ok.Value),
            _ => StatusCode(500, "unexpected error")
        };
    }
}