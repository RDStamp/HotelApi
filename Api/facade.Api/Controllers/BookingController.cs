using facade.Core.Services.Booking;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace facade.Api.Controllers;

[ApiController]
[Route("api/bookings")]
public class BookingController : Controller
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService BookingService)
    {
        _bookingService = BookingService;
    }    

    [HttpPost]
    [Route("booking")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesErrorResponseType(typeof(void))]
    public async Task<IActionResult> PostBooking()
    {
        // json payload Start, End, Guests[], room 

        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("booking")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteBooking([FromQuery] string? bookingId)
    {
        throw new NotImplementedException();
     }

    [HttpGet]
    [Route("booking")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBooking([FromQuery] string? bookingId, [FromQuery] string? guestId)
    {
        throw new NotImplementedException();
    }

}