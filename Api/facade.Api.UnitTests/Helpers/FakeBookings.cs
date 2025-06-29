using facade.Data.Entities.Public;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace facade.Api.UnitTests.Helpers;

public class FakeBookings
{
    public static DbSet<Booking> GetBookings()
    {
        DbSet<Booking> bookings = new Mock<DbSet<Booking>>().Object;

        

        return bookings;

    }
}