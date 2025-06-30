using System.ComponentModel.DataAnnotations;

namespace facade.Core.Models;

public class BookingRequest
{
    /// <summary>
    /// Period start time for the booking.
    /// </summary>
    [Required]
    public DateTime Start { get; set; }

    /// <summary>
    /// Period end time for the booking.
    /// </summary>
    [Required]
    public DateTime End { get; set; }

    /// <summary>
    /// List of Guest Ids that are to be part of this booking for the given period
    /// </summary>
    [Required]
    public List<int> GuestIdList { get; set; } = new List<int>();

    /// <summary>
    /// Room Id that is to be booked for the given period
    /// </summary>
    [Required]
    public int RoomId { get; set; }
}
