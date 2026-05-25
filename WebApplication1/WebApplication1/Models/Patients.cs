using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("Patients")]
public class Patients
{
    [Key, Column(TypeName =  "char(11)")]
    public string Pesel { get; set; } = string.Empty;
    [Column(TypeName ="nvarchar(50)")]
    public string FirstName { get; set; } = string.Empty;
    [Column(TypeName ="nvarchar(100)")]
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    [Column(TypeName ="bit")]
    public bool Sex  { get; set; }
    
    public IEnumerable<BedAssignments> BedAssignments { get; set; } = [];
    public IEnumerable<Admissions> Admissions { get; set; } = [];
}