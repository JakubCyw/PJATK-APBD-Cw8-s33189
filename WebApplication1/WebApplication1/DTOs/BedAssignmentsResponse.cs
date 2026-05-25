namespace WebApplication1.DTOs;

public record BedAssignmentsResponse(
    int Id,
    DateTime From,
    DateTime? To,
    BedsResponse Bed
    );