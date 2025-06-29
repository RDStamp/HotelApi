using facade.Core.Helpers;

namespace facade.Core.Services.Seeding;

public interface ISeedingService
{

    Task<Result> GetSeeding();

    Task<Result> DeleteSeeding();
}
