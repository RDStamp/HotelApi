using facade.Core.Helpers;
using facade.Data.Entities.Public;

namespace facade.Core.Services.HotelService;

public interface IHotelService
{

    Task<Result<Hotel>> GetHotelByName(string? name);

    Task<Result<List<Hotel>>> GetAvailable(string? start, string? end);
}
