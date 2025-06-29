using facade.Core.Helpers;
using Microsoft.Extensions.Configuration;
namespace facade.Core.Services.Hotel;

public class HotelService : IHotelService
{
    public HotelService()
    {
    }

    public async Task<Result> GetHotelByName( string? name)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> GetAvailable( string? start,  string? end)
    {
        throw new NotImplementedException();
    }
}
