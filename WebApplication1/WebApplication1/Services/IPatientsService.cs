using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface IPatientsService
{
    Task<IEnumerable<PatientsResponse>> GetAllPatientsAsync(string? search, CancellationToken cancellationToken);
    Task<IResult> AssignBedAsync(string pesel, BedAssignmentRequest request, CancellationToken cancellationToken);
}