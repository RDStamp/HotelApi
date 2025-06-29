namespace facade.Core.Models;

public class BookingRequest
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public List<int> Guests { get; set; } = new List<int>();
    public int RoomId { get; set; }
}
