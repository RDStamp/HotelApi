using facade.Core.Helpers;
using facade.Data.Data;
using facade.Data.Entities.Public;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace facade.Core.Services.HotelService;

public class HotelService : IHotelService
{
    private readonly BookingsDBContext _context;
    public HotelService(BookingsDBContext context)
    {
        _context = context;
    }

    public async Task<Result<Hotel>> GetHotelByName(string? name)
    {
        try
        {
            using (_context)
            {
                Hotel? hotel = await _context.Hotels.Where(a => a.FullName == name).FirstOrDefaultAsync();

                if (hotel == null)
                {
                    return Result<Hotel>.FailedResult("Hotel not found", StatusCodes.Status404NotFound);
                }

                return Result<Hotel>.SuccessResult(hotel);
            }
        }
        catch
        {
            return Result<Hotel>.FailedResult("Failed to find hotels", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<Result<List<Hotel>>> GetAvailable(string? start, string? end)
    {
        try
        {
            var startDate = DateTime.TryParse(start, out DateTime startDateTime) ? startDateTime : DateTime.MinValue;
            var endDate = DateTime.TryParse(end, out DateTime endDateTime) ? endDateTime : DateTime.MaxValue;

            if (startDate == DateTime.MinValue || endDate == DateTime.MinValue)
            {
                return Result<List<Hotel>>.FailedResult("Invalid date format", StatusCodes.Status400BadRequest);
            }

            if (startDate > endDate)
            {
                return Result<List<Hotel>>.FailedResult("Invalid date range", StatusCodes.Status400BadRequest);
            }

            using (_context)
            {
                List<Hotel> hotels = await _context.Rooms
                    .Join(_context.Bookings,
                        room => room.Id,
                        booking => booking.RoomId,
                        (room, booking) => new { room, booking })
                    .Join(_context.Hotels,
                        room => room.room.HotelId,
                        hotel => hotel.Id,
                        (room, hotel) => new { room, hotel })
                    .Where(x => x.room.booking.EndDate < startDate || x.room.booking.StartDate > endDate)
                    .Select(x => x.hotel)
                    .Distinct()
                    .ToListAsync();


                if (!hotels.Any())
                {
                    return Result<List<Hotel>>.FailedResult("Availability not found", StatusCodes.Status404NotFound);
                }

                return Result<List<Hotel>>.SuccessResult(hotels);
            }
        }
        catch
        {
            return Result<List<Hotel>>.FailedResult("Failed to find hotels", StatusCodes.Status500InternalServerError);
        }
    }
}
