using facade.Core.Helpers;
using facade.Data.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace facade.Core.Services.Seeding;

public class SeedingService : ISeedingService
{
    private readonly BookingsDBContext _context;
    public SeedingService(BookingsDBContext context)
    {
        _context = context;
    }

    public async Task<Result<string>> GetSeeding()
    {
        try
        {
            using (_context)
            {
                var results = await _context.Database.ExecuteSqlAsync($"EXEC PopulateDbTestData");
            }

            return Result<string>.SuccessResult("Data Added");
        }
        catch
        {
            return Result<string>.FailedResult("Failed to add data", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<Result<string>> DeleteSeeding()
    {
        try
        {
            using (_context)
            {
                var results = await _context.Database.ExecuteSqlAsync($"EXEC DeleteDbTestData");
            }

            return Result<string>.SuccessResult("Data Deleted");
        }
        catch
        {
            return Result<string>.FailedResult("Failed to deleted d", StatusCodes.Status500InternalServerError);
        }
    }
}