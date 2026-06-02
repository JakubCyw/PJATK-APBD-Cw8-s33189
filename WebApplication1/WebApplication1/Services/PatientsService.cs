using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Infrastructure;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class PatientsService(DatabaseContext ctx) : IPatientsService
{
    public async Task<IEnumerable<PatientsResponse>> GetAllPatientsAsync(string? search, CancellationToken cancellationToken)
    {
        var query = ctx.Patients.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var s =  search.Trim().ToLower();
            
            query = query.Where(p => p.FirstName.ToLower().Contains(s) || p.LastName.ToLower().Contains(s));
        }
        
        return await query.Select(p => new PatientsResponse(
            p.Pesel,
            p.FirstName,
            p.LastName,
            p.Age,
            p.Sex ? "Female" : "Male",
            p.Admissions.Select(a => new AdmissionsResponse(
                a.Id,
                a.AdmissionDate,
                a.DischargeDate,
                new WardsResponse(
                    a.Ward.Id,
                    a.Ward.Name,
                    a.Ward.Description
                )
            )),
            p.BedAssignments.Select(ba => new BedAssignmentsResponse(
                ba.Id,
                ba.From,
                ba.To,
                new BedsResponse(
                    ba.Bed.Id,
                    new BedTypesResponse(
                        ba.Bed.BedType.Id,
                        ba.Bed.BedType.Name,
                        ba.Bed.BedType.Description
                    ),
                    new RoomsResponse(
                        ba.Bed.Room.Id,
                        ba.Bed.Room.HasTv,
                        new WardsResponse(
                            ba.Bed.Room.ward.Id,
                            ba.Bed.Room.ward.Name,
                            ba.Bed.Room.ward.Description
                            )
                    )
                )
            ))
        )).ToListAsync(cancellationToken);
    }

    public async Task<IResult> AssignBedAsync(string pesel, BedAssignmentRequest request, CancellationToken cancellationToken)
    {
        var peselExists = await ctx.Patients.AnyAsync(p => p.Pesel == pesel, cancellationToken);
        if (!peselExists)
        {
            return Results.NotFound(new { message = $"Not found patient witk pesel: {pesel}"});
        }

        if (request.To.HasValue && request.From >= request.To.Value)
        {
            return Results.BadRequest(new { Message = "From date must be earlier than To date" });
        }

        var wardExists = await ctx.Wards.AnyAsync(w => w.Name == request.Ward, cancellationToken);
        if (!wardExists)
        {
            return Results.NotFound(new { Message = $"Ward {request.Ward} not found" });
        }

        var bedTypeExists = await ctx.BedTypes.AnyAsync(bt => bt.Name == request.BedType, cancellationToken);
        if (!bedTypeExists)
        {
            return Results.NotFound(new { Message = $"BedType {request.BedType} not found" });
        }

        var beds = await ctx.Beds
            .Where(b => b.Room.ward.Name == request.Ward && b.BedType.Name == request.BedType)
            .Include(b => b.BedAssignments)
            .ToListAsync(cancellationToken);
        if (!beds.Any())
        {
            return Results.NotFound(new { Message = $"No matching beds found" });
        }

        Beds? availableBed = null;

        foreach (var bed in beds)
        {
            bool hasCollision = bed.BedAssignments.Any(ba =>
            {
                DateTime currentTo = ba.To ?? DateTime.MaxValue;

                DateTime requestTo = request.To ?? DateTime.MaxValue;

                return request.From < currentTo && requestTo > ba.From;
            });

            if (!hasCollision)
            {
                availableBed = bed;
                break;
            }
        }

        if (availableBed == null)
        {
            return Results.NotFound(new {Message = $"Not Found Bed" });
        }

        var newAssignment = new BedAssignments
        {
            PatientPesel = pesel,
            BedId =  availableBed.Id,
            From =  request.From,
            To =  request.To
        };

        ctx.BedAssigments.Add(newAssignment);
        await ctx.SaveChangesAsync(cancellationToken);
        
        return Results.Ok(new { Message = "Successfully assigned bed" });
    }
}