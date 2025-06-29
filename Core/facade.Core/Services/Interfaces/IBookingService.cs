using facade.Core.Helpers;
using facade.Core.Models;

namespace facade.Core.Services.BookingService;

public interface IBookingService
{
    Task<Result<string>> PostBooking(BookingRequest request);

    Task<Result<string>> DeleteBooking(string? bookingId);

    Task<Result<BookingDto>> GetBooking(string? bookingId);
}
