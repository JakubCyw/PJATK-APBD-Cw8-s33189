using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("BadAssignments")]
public class BedAssignments
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "char(11)")]
    public string PatientPesel { get; set; } = string.Empty;
    public int BedId { get; set; }
    public DateTime From  { get; set; }
    public DateTime? To { get; set; }

    [ForeignKey("PatientPesel")]
    public Patients Patient { get; set; } = null!;
    
    [ForeignKey("BedId")]
    public Beds Bed { get; set; } = null!;
}