using facade.Core.Services.Hotel;
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }   
}