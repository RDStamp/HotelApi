using facade.Core.Services.Seeding;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace facade.Api.Controllers;

[ApiController]
[Route("api/seeding")]
public class SeedingController : Controller
{
    private readonly ISeedingService _SeedingService;

    public SeedingController(ISeedingService SeedingService)
    {
        _SeedingService = SeedingService;
    }

    [HttpPut]
    [Route("seeding")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesErrorResponseType(typeof(void))]
    public async Task<IActionResult> GetSeeding([FromQuery] string? name)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("seeding")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesErrorResponseType(typeof(void))]
    public async Task<IActionResult> DeleteSeeding()
    {
        throw new NotImplementedException();
    }   
}