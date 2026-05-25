using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Infrastructure;

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
}