using facade.Core.Helpers;

namespace facade.Core.Services.Booking;

public interface IBookingService
{
    Task<Result> PostBooking();

    Task<Result> DeleteBooking(string? bookingId);

    Task<Result> GetBooking(string? bookingId, string? guestId);
}
