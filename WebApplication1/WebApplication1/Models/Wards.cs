using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("Wards")]
public class Wards
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(300)")]
    public string Name { get; set; } = string.Empty;
    [Column(TypeName = "nvarchar(max)")]
    public string Description { get; set; } = string.Empty;
    
    public IEnumerable<Rooms> Rooms { get; set; } = [];
    public IEnumerable<Admissions> Admissions { get; set; } = [];
}