using facade.Core.Services.HotelService;

namespace facade.Core.UnitTests.Services;

public class HotelServiceTests
{
    [Fact]
    public void GetHotelByName_WithNullName_ReturnsBadRequestStatus()
    {

        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void GetHotelByName_WithEmptyName_ReturnsBadRequestStatus()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
        public void GetHotelByName_WithValidName_ReturnsSuccessStatusHavingHotel()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void GetHotelByName_WithNonExistentName_ReturnsNotFoundStatus()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void GetAvailability_WithNullStart_ReturnsBadRequest()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void GetAvailability_WithNullEnd_ReturnsBadRequest()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void GetAvailability_WithInvalidStart_ReturnsBadRequest()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void GetAvailability_WithInvalidEnd_ReturnsBadRequest()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void GetAvailability_WithValidDates_ReturnsSuccessStatusHavingAvailability()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }

    [Fact]
    public void GetAvailability_WithNoAvailableRooms_ReturnsNotFoundStatus()
    {
        throw new NotImplementedException("This test is not implemented yet.");
    }
}
