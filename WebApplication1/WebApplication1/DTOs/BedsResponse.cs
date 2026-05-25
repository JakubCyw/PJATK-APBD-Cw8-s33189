namespace WebApplication1.DTOs;

public record BedsResponse(
    int Id,
    BedTypesResponse BedType,
    RoomsResponse Room
    );