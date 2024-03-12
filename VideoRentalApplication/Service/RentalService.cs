using Microsoft.EntityFrameworkCore;
using VideoRentalApplication.Models;

// RentalService.cs
public class RentalService
{
    private readonly VideoRentalDbContext _dbContext;

    public RentalService(VideoRentalDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateRental(int customerId, List<int> movieIds)
    {
        var customer = await _dbContext.Customers.FindAsync(customerId);
        if (customer == null)
        {
            throw new ArgumentException("Customer not found.");
        }

        foreach (var movieId in movieIds)
        {
            var movie = await _dbContext.Movies.FindAsync(movieId);  // Find the movie first
            if (movie == null)
            {
                // Handle movie not found scenario (optional)
                continue;
            }

            var rental = new Rental
            {
                Customer = customer,
                Movie = movie,  // Set the Movie property
                RentalDate = DateTime.Now
            };
            _dbContext.Rental.Add(rental);
        }
        await _dbContext.SaveChangesAsync();
    }





    public async Task ReturnRental(List<int> movieIds)
    {
        foreach (var movieId in movieIds)
        {
            //var rental = await _dbContext.Rental.FirstOrDefaultAsync(r => r.MovieId == movieId && r.ReturnDate == null);
            var rental = await _dbContext.Rental.FirstOrDefaultAsync(r => r.MovieId == movieId && r.ReturnDate == DateTime.MinValue);

            if (rental != null)
            {
                rental.ReturnDate = DateTime.Now;
            }
        }
        await _dbContext.SaveChangesAsync();
    }

    public async Task ReturnAllRental()
    {
        var rentals = await _dbContext.Rental.Where(r => r.ReturnDate == null).ToListAsync();
        foreach (var rental in rentals)
        {
            rental.ReturnDate = DateTime.Now;
        }
        await _dbContext.SaveChangesAsync();
    }



}