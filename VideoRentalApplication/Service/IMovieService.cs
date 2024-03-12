using Microsoft.EntityFrameworkCore;
using VideoRentalApplication.Models;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetMoviesAsync();
    Task<Movie> GetMovieByIdAsync(int id);
    Task<Movie> CreateMovieAsync(Movie movie);
    Task<Movie> UpdateMovieAsync(int id, Movie movie);
    Task<bool> DeleteMovieAsync(int id);
}

public class MovieService : IMovieService
{
    private readonly VideoRentalDbContext _dbContext;

    public MovieService(VideoRentalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Movie>> GetMoviesAsync()
    {
        return await _dbContext.Movies.ToListAsync();
    }

    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.MovieId == id);
        if (movie == null)
        {
            throw new ArgumentException("Movie not found", nameof(id));
        }

        return movie;
    }


    public async Task<Movie> CreateMovieAsync(Movie movie)
    {
        _dbContext.Movies.Add(movie);
        await _dbContext.SaveChangesAsync();
        return movie;
    }

    public async Task<Movie> UpdateMovieAsync(int id, Movie movie)
    {
        var existingMovie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.MovieId == id);
        if (existingMovie == null)
        {
            throw new ArgumentException("Movie not found", nameof(id));
        }

        existingMovie.Title = movie.Title;
        existingMovie.ReleaseDate = movie.ReleaseDate;
        existingMovie.Genre = movie.Genre;

        await _dbContext.SaveChangesAsync();
        return existingMovie;
    }

    public async Task<bool> DeleteMovieAsync(int id)
    {
        var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.MovieId == id);
        if (movie == null)
        {
            return false;
        }

        _dbContext.Movies.Remove(movie);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
