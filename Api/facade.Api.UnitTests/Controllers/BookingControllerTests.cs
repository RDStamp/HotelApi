using facade.Api.Controllers;
using facade.Api.UnitTests.Helpers;
using facade.Core.Services.BookingService;
using facade.Data.Data;
using facade.Data.Entities.Public;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace facade.Api.UnitTests.Controllers;

public class BookingControllerTests
{
    private Mock<BookingsDBContext> _bookingContextMock = null!;
    private BookingService _bookingService = null!;
    private BookingController _bookingController = null!;
    
    public BookingControllerTests()
    {
        DbContextOptions<BookingsDBContext> dbContextOptions = new DbContextOptionsBuilder<BookingsDBContext>()
            .Options;

        _bookingContextMock = new Mock<BookingsDBContext>(dbContextOptions);
        _bookingContextMock.Setup(x => x.Set<Booking>()).Returns(FakeBookings.GetBookings());

        _bookingService = new BookingService(_bookingContextMock.Object);

        _bookingController = new BookingController(_bookingService);
    }

    [Fact]  
    public void GetBookingById_WithValidId_ReturnsBooking()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void GetBookingById_WithInvalidId_ReturnsNotFound()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }   

    [Fact]  
    public void GetBookingById_WithNullId_ReturnsBadRequest()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void GetBookingById_WithEmptyId_ReturnsBadRequest()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void DeleteBookingById_WithValidId_ReturnsOkResult()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void DeleteBookingById_WithInvalidId_ReturnsNotFound()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void DeleteBookingById_WithNullId_ReturnsBadRequest()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void DeleteBookingById_WithEmptyId_ReturnsBadRequest()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void PostBooking_WithValidRequest_ReturnsOkResult()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void PostBooking_WithInvalidRequest_ReturnsBadRequest()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void PostBooking_WithNullRequest_ReturnsBadRequest()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void PostBooking_WithEmptyRequest_ReturnsBadRequest()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }
}
