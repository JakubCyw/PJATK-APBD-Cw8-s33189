using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("Rooms")]
public class Rooms
{
    [Key, Column(TypeName = "varchar(4)")]
    public string Id { get; set; } = string.Empty;
    public int WardId { get; set; }
    [Column(TypeName = "bit")]
    public bool HasTv { get; set; }
    
    [ForeignKey("WardId")] 
    public Wards ward { get; set; } = null!;
    
    public IEnumerable<Beds> Beds { get; set; } = [];

}