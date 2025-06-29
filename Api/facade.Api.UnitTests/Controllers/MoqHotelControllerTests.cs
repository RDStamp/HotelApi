using facade.Api.UnitTests.Moqs;
using facade.Core.Helpers;
using facade.Core.Services.HotelService;
using facade.Data.Entities.Public;
using Microsoft.AspNetCore.Http;

namespace facade.Api.UnitTests.Controllers;


public class MoqHotelControllerTests
{
    private IHotelService _mockHotelService = null!;

    [Fact]
    public void GetHotelByName_WithNullName_ReturnsBadRequestStatus()
    {
        // Arrange
        var controller = new MoqHotelService(_mockHotelService);

        // Act
        var controllerResponse = controller.GetHotelByName(null);


        //Assert
        Assert.NotNull(controllerResponse);
        Assert.IsType<Result<Hotel>>(controllerResponse.Result);
        var result = controllerResponse.Result;
        Assert.False(result.IsSuccess);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }

    [Fact]
    public void GetHotelByName_WithEmptyName_ReturnsBadRequestStatus()
    {
        // Arrange
        var controller = new MoqHotelService(_mockHotelService);

        // Act
        var controllerResponse = controller.GetHotelByName(string.Empty);


        //Assert
        Assert.NotNull(controllerResponse);
        Assert.IsType<Result<Hotel>>(controllerResponse.Result);
        var result = controllerResponse.Result;
        Assert.False(result.IsSuccess);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);

    }

    [Fact]
    public void GetHotelByName_WithValidNameName_ReturnsSuccessStatusHavingHotel()
    {
        // Arrange
        var name = "Moq Test Hotel";
        var controller = new MoqHotelService(_mockHotelService);

        // Act
        var controllerResponse = controller.GetHotelByName(name);


        //Assert
        Assert.NotNull(controllerResponse);
        Assert.IsType<Result<Hotel>>(controllerResponse.Result);
        var result = controllerResponse.Result;
        Assert.True(result.IsSuccess);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        Assert.Equal(name, result.Value.FullName);
    }
}
