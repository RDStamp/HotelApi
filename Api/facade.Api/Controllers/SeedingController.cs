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

    /// <summary>
    /// Seeds the DB with initial data, contained in the SP dedicated for this task
    /// </summary>
    /// 
    /// <returns>
    ///     Returns a string indicating the seeding status, or an error message if the seeding fails.
    /// </returns>
    [HttpPut]
    [Route("seeding")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

    /// <summary>
    /// Deletes Seeding data from the DB, contained in the SP dedicated for this task
    /// </summary>
    /// 
    /// <returns>
    ///     Returns a string indicating the deletion status, or an error message if the deletion fails.
    /// </returns>
    [HttpDelete]
    [Route("seeding")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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