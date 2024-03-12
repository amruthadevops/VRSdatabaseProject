using System.ComponentModel.DataAnnotations;

namespace VideoRentalApplication.Models
{
    public class Movie
    {
        
        public int MovieId { get; set; }
        public required string Title { get; set; }

        public required string Description { get; set; }

        public required string Genre { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public required string Language { get; set; }
        public required ICollection<Rental> Rental { get; set; }
        //public ICollection<Return> Return { get; set; }

    }
}
