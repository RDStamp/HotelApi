using facade.Core.Helpers;
using facade.Core.Services.HotelService;
using facade.Data.Entities.Public;
using Microsoft.AspNetCore.Http;

namespace facade.Api.UnitTests.Moqs;

public class MoqHotelService : IHotelService
{
    private readonly IHotelService _hotelService;

    public MoqHotelService(IHotelService HotelService)
    {
        _hotelService = HotelService;
    }

    public Task<Result<Hotel>> GetHotelByName(string? name)
    {

        if (string.IsNullOrWhiteSpace(name))
        {
            return Task.FromResult(Result<Hotel>.FailedResult("Hotel name cannot be null or empty.", StatusCodes.Status400BadRequest));
        }

        var hotel = new Hotel { Address = "123 Main St", FullName = name, Postcode = "12345", Tel_No = "123-456-7890", Email = "emailaddress@gmail.com" };

        return Task.FromResult(Result<Hotel>.SuccessResult(hotel));
    }

    public Task<Result<List<Hotel>>> GetAvailable(string? start, string? end)
    {
        var startDate = DateTime.TryParse(start, out DateTime startDateTime) ? startDateTime : DateTime.MinValue;
        var endDate = DateTime.TryParse(end, out DateTime endDateTime) ? endDateTime : DateTime.MaxValue;

        if (startDate == DateTime.MinValue || endDate == DateTime.MinValue)
        {
            return Task.FromResult(Result<List<Hotel>>.FailedResult("Invalid date format", StatusCodes.Status400BadRequest));
        }

        if (startDate > endDate)
        {
            return Task.FromResult(Result<List<Hotel>>.FailedResult("Invalid date range", StatusCodes.Status400BadRequest));
        }

        var hotels = new List<Hotel>();
        var hotel = new Hotel { Address = "123 Main St", FullName = "Moq Test Hotel", Postcode = "12345", Tel_No = "123-456-7890", Email = "emailaddress@gmail.com" };
        hotels.Add(hotel);

        if (!hotels.Any())
        {
            return Task.FromResult(Result<List<Hotel>>.FailedResult("Availability not found", StatusCodes.Status404NotFound));
        }

        return Task.FromResult(Result<List<Hotel>>.SuccessResult(hotels));
    }
}