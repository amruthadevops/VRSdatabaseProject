// RentalController.cs
using Microsoft.AspNetCore.Mvc;
using VideoRentalApplication.Models;

[Route("api/[controller]")]
[ApiController]
public class RentalController : ControllerBase
{
    private readonly RentalService _rentalService;

    public RentalController(RentalService rentalService)
    {
        _rentalService = rentalService;
    }

    // Endpoint for renting multiple movies
    [HttpPost("rent")]
    public async Task<IActionResult> RentMovies([FromBody] List<int> movieIds, int customerId)  // Add customerId parameter
    {
        try
        {
            await _rentalService.CreateRental(customerId, movieIds);  // Pass both arguments
            return Ok("Movies rented successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }


    // Endpoint for returning movies (option 1: using checkbox system)
    [HttpPost("return")]
    public async Task<IActionResult> ReturnMovies([FromBody] List<int> movieIds)
    {
        try
        {
            await _rentalService.ReturnRental(movieIds);
            return Ok("Movies returned successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    // Endpoint for returning all movies (option 2: separate buttons)
    [HttpPost("returnAll")]
    public async Task<IActionResult> ReturnAllMovies()
    {
        try
        {
            await _rentalService.ReturnAllRental();
            return Ok("All movies returned successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}

