namespace WebApplication1.DTOs;

public record AdmissionsResponse(
    int Id,
    DateTime AdmissionDate,
    DateTime? DischargeDate,
    WardsResponse Ward
    );