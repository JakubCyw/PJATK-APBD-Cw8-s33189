namespace WebApplication1.DTOs;

public record PatientsResponse(
    string Pesel,
    string FirstName,
    string LastName,
    int Age,
    string Sex,
    IEnumerable<AdmissionsResponse> Admissions,
    IEnumerable<BedAssignmentsResponse> BedAssignments
    );