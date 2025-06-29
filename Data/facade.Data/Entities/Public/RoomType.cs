using facade.Data.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace facade.Data.Entities.Public;

[Table("RoomTypes")]
public class RoomType : Entity
{
    public required string Name { get; set; } = null!;

    public string Detail { get; set; } = null!;

    public ICollection<Room> Rooms { get; set; } = [];
}