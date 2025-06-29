using facade.Data.Entities.Base;
using facade.Data.Entities.Public;
using System.ComponentModel.DataAnnotations.Schema;

namespace facade.Data.Entities.Public;

[Table("Bookings")]
public class Booking : Entity
{
    public required DateTime StartDate { get; set; }

    public required DateTime EndDate { get; set; }

    public int RoomId { get; set; }

    public Room Room { get; } = null!;

    public Guid RefId { get; set; }

    public List<BookingGuests> BookingGuests { get; } = [];
}