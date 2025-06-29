using facade.Core.Services.Seeding;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
    public async Task<IActionResult> GetSeeding()
    {
        try
        {
            var result = await _SeedingService.GetSeeding();

            return Ok(result);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.ValidationResult);
        }
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
        try
        {
            var result = await _SeedingService.DeleteSeeding();

            return Ok(result);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.ValidationResult);
        }

    }
}