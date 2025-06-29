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