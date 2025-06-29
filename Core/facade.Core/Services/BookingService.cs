using facade.Core.Helpers;
using facade.Core.Models;
using facade.Data.Data;
using facade.Data.Entities.Public;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace facade.Core.Services.BookingService;

public class BookingService : IBookingService
{
    private readonly BookingsDBContext _context;
    public BookingService(BookingsDBContext context)
    {
        _context = context;
    }

    public async Task<Result<string>> PostBooking(BookingRequest request)
    {
        try
        {
            var room = await _context.Rooms
            .FirstOrDefaultAsync(r => r.Id == request.RoomId);

            if (room == null || room.Capacity < request.Guests.Count())
            {
                return Result<string>.FailedResult("Failed to add booking, occupancy limit exceeded", StatusCodes.Status400BadRequest);
            }

            var booking = new Booking
            {
                RefId = Guid.NewGuid(),
                RoomId = request.RoomId,
                StartDate = request.Start,
                EndDate = request.End
            };

            var addedBooking = (Booking)(await _context.Bookings.AddAsync(booking)).Entity;

            await _context.SaveChangesAsync();

            var bookingGuests = new List<BookingGuests>();
            foreach (var guest in request.Guests)
            {
                var newEnrty = new BookingGuests
                {
                    GuestId = guest,
                    BookingId = addedBooking.Id
                };
                _context.BookingGuests.Add(newEnrty);
            }

            await _context.SaveChangesAsync();

            return Result<string>.SuccessResult(addedBooking.RefId.ToString());
        }
        catch
        {
            return Result<string>.FailedResult("Failed to delete booking", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<Result<string>> DeleteBooking(string? bookingId)
    {
        try
        {
            Guid newGuid;

            if (!Guid.TryParse(bookingId, out newGuid) && string.IsNullOrEmpty(bookingId))
            {
                return Result<string>.FailedResult("Invalid RefId", StatusCodes.Status500InternalServerError);
            }

            var itemToRemove = await _context.Bookings
                .Where(x => x.RefId == newGuid)
                .ToListAsync();

            _context.Bookings.RemoveRange(itemToRemove);
            _context.SaveChanges();

            return Result<string>.SuccessResult("Booking Data Deleted");
        }
        catch
        {
            return Result<string>.FailedResult("Failed to delete booking", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<Result<BookingDto>> GetBooking(string? bookingId)
    {
        try
        {
            Guid newGuid;

            if (!Guid.TryParse(bookingId, out newGuid) && string.IsNullOrEmpty(bookingId))
            {
                return Result<BookingDto>.FailedResult("Invalid RefId", StatusCodes.Status500InternalServerError);
            }

            using (_context)
            {
                var currentBookings = _context.Bookings
                    .Join(_context.BookingGuests,
                        booking => booking.Id,
                        bookingGuest => bookingGuest.BookingId,
                        (booking, bookingGuest) => new { booking, bookingGuest })
                    .Where(x => x.booking.RefId == newGuid)
                    .ToList();

                if (!currentBookings.Any())
                {
                    return Result<BookingDto>.FailedResult("No bookings found", StatusCodes.Status404NotFound);
                }

                var currentGuests = await _context.Guests
                    .Where(x => currentBookings.Select(c => c.bookingGuest.GuestId).Contains(x.Id))
                    .Distinct()
                    .ToListAsync();

                var currentRooms = await _context.Rooms
                    .Join(_context.Hotels,
                        room => room.HotelId,
                        hotel => hotel.Id,
                        (room, hotel) => new { room, hotel })
                    .Join(_context.RoomTypes,
                        x => x.room.RoomTypeId,
                        roomType => roomType.Id,
                        (x, roomType) => new { x.hotel, x.room, roomType })
                    .Where(x =>
                        currentBookings.Select(c => c.booking.RoomId).Contains(x.room.Id))
                    .Distinct()
                    .FirstOrDefaultAsync();

                if (currentRooms == null)
                {
                    return Result<BookingDto>.FailedResult("No bookings found", StatusCodes.Status404NotFound);
                }

                List<DtoGuest> guestList = new List<DtoGuest>();

                foreach (var guest in currentGuests)
                {
                    guestList.Add(new DtoGuest
                    {
                        FullName = guest.FullName,
                        Surname = guest.Surname,
                        Tel_No = guest.Tel_No,
                        Email = guest.Email
                    });
                }

                var result = new BookingDto
                {
                    RefId = newGuid,
                    Hotel = new DtoHotel
                    {
                        FullName = currentRooms.hotel.FullName,
                        Address = currentRooms.hotel.Address,
                        Postcode = currentRooms.hotel.Postcode,
                        Tel_No = currentRooms.hotel.Tel_No,
                        Email = currentRooms.hotel.Email
                    },
                    Room = new DtoRoom
                    {
                        Number = currentRooms.room.Number,
                        Capacity = currentRooms.room.Capacity,
                        Name = currentRooms.roomType.Name,
                        Detail = currentRooms.roomType.Detail
                    },
                    Start = currentBookings.First().booking.StartDate,
                    End = currentBookings.First().booking.EndDate,

                    Guests = guestList
                };

                if (!currentBookings.Any())
                {
                    return Result<BookingDto>.FailedResult("Availability not found", StatusCodes.Status404NotFound);
                }

                return Result<BookingDto>.SuccessResult(result);
            }
        }
        catch
        {
            return Result<BookingDto>.FailedResult("Failed to find availability", StatusCodes.Status500InternalServerError);
        }
    }
}