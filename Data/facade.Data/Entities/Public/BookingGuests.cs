using facade.Data.Entities.Base;
using facade.Data.Entities.Public;

namespace facade.Data.Entities.Public;
public class BookingGuests : Entity
{
    public int BookingId { get; set; }
    public Booking Booking { get; set; } = null!;
    public int GuestId { get; set; }
    public Guest Guest { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
