using facade.Core.Helpers;
using Microsoft.Extensions.Configuration;
namespace facade.Core.Services.Booking;

public class BookingService : IBookingService
{
    public BookingService(IConfiguration config)
    {
    }

    public async Task<Result> PostBooking()
    {
        // json payload Start, End, Guests[], room 

        throw new NotImplementedException();
    }

     public async Task<Result> DeleteBooking( string? bookingId)
    {
        throw new NotImplementedException();
    }


    public async Task<Result> GetBooking( string? bookingId,  string? guestId)
    {
        throw new NotImplementedException();
    }
}
