using facade.Api.Controllers;
using facade.Api.UnitTests.Helpers;
using facade.Core.Helpers;
using facade.Core.Services.HotelService;
using facade.Data.Data;
using facade.Data.Entities.Public;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace facade.Api.UnitTests.Controllers;

public class HotelControllerTests
{

    private Mock<BookingsDBContext> _hotelContextMock = null!;
    private HotelService _hotelService = null!;
    private HotelController _hotelController = null!;

    public HotelControllerTests()
    {
        DbContextOptions<BookingsDBContext> dbContextOptions = new DbContextOptionsBuilder<BookingsDBContext>()
            .Options;

        _hotelContextMock = new Mock<BookingsDBContext>(dbContextOptions);
        _hotelContextMock.Setup(x => x.Set<Hotel>()).Returns(FakeHotels.GetHotels());

        _hotelService = new HotelService(_hotelContextMock.Object);

        _hotelController = new HotelController(_hotelService);
    }


    [Fact]
    public void GetHotelByName_WithNullName_ReturnsBadRequestStatus()
    {
        // Arrange

        // Act
        var controllerResponse = _hotelController.GetHotelByName(null);


        //Assert
        Assert.NotNull(controllerResponse);
        Assert.IsType<BadRequestObjectResult>(controllerResponse.Result);
        var result = (ObjectResult)controllerResponse.Result;
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }

    [Fact]
    public void GetHotelByName_WithEmptyName_ReturnsBadRequestStatus()
    {
        // Arrange

        // Act
        var controllerResponse = _hotelController.GetHotelByName(string.Empty);


        //Assert
        Assert.NotNull(controllerResponse);
        Assert.IsType<BadRequestObjectResult>(controllerResponse.Result);
        var result = (ObjectResult)controllerResponse.Result;
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }

    [Fact]
    public void GetHotelByName_WithValidNameName_ReturnsSuccessStatusHavingHotel()
    {
        // Arrange
        var name = "Moq Test Hotel";

        // Act
        var controllerResponse = _hotelController.GetHotelByName(name);


        //Assert
        Assert.NotNull(controllerResponse);
        Assert.IsType<Result<Hotel>>(controllerResponse.Result);
        //var result = controllerResponse.Result;
        //Assert.True(result.IsSuccess);
        //Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        //Assert.Equal(name, result.Value.FullName);
    }
}

