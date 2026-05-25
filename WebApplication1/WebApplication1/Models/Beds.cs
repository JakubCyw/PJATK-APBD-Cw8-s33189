using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("Beds")]
public class Beds
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName ="varchar(4)")]
    public string RoomId { get; set; } = string.Empty;
    public int BedTypeId { get; set; }

    [ForeignKey("RoomId")] 
    public Rooms Room { get; set; } = null!;
    [ForeignKey("BedTypeId")]
    public BedTypes BedType { get; set; } = null!;

    
    public IEnumerable<BedAssignments> BedAssignments { get; set; } = [];
}