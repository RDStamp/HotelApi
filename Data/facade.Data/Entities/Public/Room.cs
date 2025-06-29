using facade.Data.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace facade.Data.Entities.Public;

[Table("Rooms")]
public class Room : Entity
{

    public required int Number { get; set; }

    public required int Capacity { get; set; }

    public int HotelId { get; set; }

    public Hotel Hotel { get; } = null!;

    public int RoomTypeId { get; set; }

    public RoomType RoomType { get; set; } = null!;

    public ICollection<Booking> Bookings { get; set; } = [];

}
