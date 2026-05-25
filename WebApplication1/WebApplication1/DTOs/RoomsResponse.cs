namespace WebApplication1.DTOs;

public record RoomsResponse(
    string Id,
    bool HasTv,
    WardsResponse Ward
    );