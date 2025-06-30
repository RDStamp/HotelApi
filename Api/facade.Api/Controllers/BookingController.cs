using facade.Core.Models;
using facade.Core.Services.BookingService;
using facade.Data.Entities.Public;
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

    /// <summary>
    /// Makes a booking with the supplied booking data
    /// </summary>
    /// <param name="request">JSON body containting the data to make a booking</param>
    /// /// <remarks>
    /// Sample request:
    ///
    /// POST /api/bookings/booking
    /// {
    ///     "start": "2025-06-30T09:11:39.359Z",
    ///     "end": "2025-06-30T09:11:39.359Z",
    ///     "guestIdList": [
    ///         0
    ///     ],  
    ///     "roomId": 0
    /// }
    ///
    /// </remarks>
    /// <returns>
    ///     New booking ID if successful, or an error message if the booking is invalid or fails.
    /// </returns>
    [HttpPost]
    [Route("booking")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostBooking(BookingRequest request)
    {
        try
        {
            if (request.Start == DateTime.MinValue ||
                request.End == DateTime.MinValue ||
                request.Start > request.End ||
                !request.GuestIdList.Any() ||
                request.GuestIdList.Any(g => g == 0) ||
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

    /// <summary>
    /// Deletes a booking based on the given booking ID (Guid).
    /// </summary>
    /// <param name="bookingId"></param>
    /// 
    /// <returns>
    ///     Returns the result of the deletion operation, which may include a success message or an error.
    /// </returns>
    [HttpDelete]
    [Route("booking")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
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

    /// <summary>
    /// Gets a booking based on the given booking ID (Guid).
    /// </summary>
    /// <param name="bookingId"></param>
    /// <returns>
    ///     Returns the booking details if found, or an error message if the booking ID is invalid or not found.
    /// </returns>
    [HttpGet]
    [Route("booking")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]
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