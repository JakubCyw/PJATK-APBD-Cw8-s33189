using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("Admissions")]
public class Admissions
{
    [Key]
    public int Id { get; set; }
    public DateTime AdmissionDate { get; set; }
    public DateTime? DischargeDate { get; set; }
    [Column(TypeName = "char(11)")]
    public string PatientPesel { get; set; } = string.Empty;
    public int WardId { get; set; }

    [ForeignKey("PatientPesel")]
    public Patients Patient { get; set; } = null!;
    [ForeignKey("WardId")] 
    public Wards Ward { get; set; } = null!;
}