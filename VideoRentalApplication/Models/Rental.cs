using System.ComponentModel.DataAnnotations;

namespace VideoRentalApplication.Models
{
    public class Rental
    {
        public int RentalId { get; set; }

        [Required]
        [MaxLength(10)]
        public int MovieId { get; set; }

        [Required]
        [MaxLength(10)]
        public int CustomerId { get; set; }

        [Required]
        public DateTime RentalDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        public decimal? RentalFee { get; set; }

        public decimal? LateFee { get; set; }

        public int? ReturnId { get; set; }
       // public virtual required Return Return { get; set; }
        public required Customer  Customer { get; set; }
        public required Movie Movie { get; set; }
        //public ICollection<Return> Return { get; set; }

        

    }
}
