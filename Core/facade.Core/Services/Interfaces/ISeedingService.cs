using facade.Core.Helpers;

namespace facade.Core.Services.Seeding;

public interface ISeedingService
{
    Task<Result<string>> GetSeeding();

    Task<Result<string>> DeleteSeeding();
}
