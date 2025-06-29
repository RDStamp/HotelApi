using facade.Core.Helpers;

namespace facade.Core.Services.Hotel;

public interface IHotelService
{

    Task<Result> GetHotelByName(string? name);

    Task<Result> GetAvailable(string? start, string? end);
}
