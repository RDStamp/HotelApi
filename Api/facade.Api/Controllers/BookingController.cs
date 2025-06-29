using facade.Core.Models;
using facade.Core.Services.BookingService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
    public async Task<IActionResult> PostBooking(BookingRequest request)
    {
        try
        {
            if (request.Start == DateTime.MinValue ||
                request.End == DateTime.MinValue ||
                request.Start > request.End ||
                !request.Guests.Any() ||
                request.Guests.Any(g => g == 0) ||
                request.RoomId == 0)
            {
                return BadRequest("Booking invalid data passed in");
            }

            var result = await _bookingService.PostBooking(request);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return UnprocessableEntity(result.StatusCode);

        }
        catch (ValidationException e)
        {
            return BadRequest(e.ValidationResult);
        }

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
        try
        {
            if (string.IsNullOrEmpty(bookingId))
            {
                return BadRequest("Booking ref is required");
            }

            var result = await _bookingService.DeleteBooking(bookingId);

            return Ok(result);

        }
        catch (ValidationException e)
        {
            return BadRequest(e.ValidationResult);
        }
    }

    [HttpGet]
    [Route("booking")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBooking([FromQuery] string? bookingId)
    {
        try
        {
            if (string.IsNullOrEmpty(bookingId))
            {
                return BadRequest("Booking ref or guest id is required");
            }

            var result = await _bookingService.GetBooking(bookingId);

            return Ok(result);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.ValidationResult);
        }
    }
}