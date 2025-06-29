using facade.Data.Entities.Public;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace facade.Api.UnitTests.Helpers;

public class FakeHotels
{
    public static DbSet<Hotel> GetHotels()
    {
        DbSet<Hotel> hotels = new Mock<DbSet<Hotel>>().Object;

        hotels.Add(new Hotel
        {
            Id = 1,
            FullName = "Moq Test Hotel",
            Address = "123 Test St, Test City",
            Postcode = "SD4 5TH",
            Tel_No = "2000000003",
            Email = "moq.test@hotel.com"
        });

        hotels.Add(new Hotel
        {
            Id = 2,
            FullName = "Sample Hotel",
            Address = "456 Sample Ave, Sample City",
            Tel_No = "4000000005",
            Email = "sample@hotel.com"
        });

        return hotels;

    }
}