using facade.Core.Services.HotelService;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace facade.Api.Controllers;

[ApiController]
[Route("api/hotels")]
public class HotelController : Controller
{
    private readonly IHotelService _HotelService;

    public HotelController(IHotelService HotelService)
    {
        _HotelService = HotelService;
    }

    /// <summary>
    /// Gets a hotel by its full name, must be the full name no wild searches
    /// </summary>
    /// <param name="name"></param>
    /// 
    /// <returns>
    ///     Returns a hotel object if found, or a bad request if the name is null or empty.
    /// </returns>
    [HttpGet]
    [Route("name")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesErrorResponseType(typeof(void))]
    public async Task<IActionResult> GetHotelByName([FromQuery] string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest("Hotel name cannot be null or empty.");
        }
        var result = await _HotelService.GetHotelByName(name);
        if (result.IsSuccess)
        {
            return Ok(result);
        }

        return StatusCode((int)result.StatusCode, result.ErrorMessage);
    }

    /// <summary>
    /// Gets the hotels that have availability for the given date range.
    /// </summary>
    /// <param name="start">Start date, string parameter must be a valid date format</param>
    /// <param name="end">End Date, string parameter must be a valid date format</param>
    /// 
    /// <returns>
    ///     Returns a list of hotels that have availability for the given date range.
    /// </returns>
    [HttpGet]
    [Route("available")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesErrorResponseType(typeof(void))]
    public async Task<IActionResult> GetAvailable([FromQuery] string? start, [FromQuery] string? end)
    {
        if (string.IsNullOrWhiteSpace(start) || string.IsNullOrWhiteSpace(end))
        {
            return BadRequest("Dates cannot be null or empty.");
        }

        if (!DateTime.TryParse(end, out _))
        {
            return BadRequest("Date format incorrect.");
        }

        if (!DateTime.TryParse(start, out _))
        {
            return BadRequest("Date format incorrect.");
        }

        var result = await _HotelService.GetAvailable(start, end);
        if (result.IsSuccess)
        {
            return Ok(result);
        }

        return StatusCode((int)result.StatusCode, result.ErrorMessage);
    }
}