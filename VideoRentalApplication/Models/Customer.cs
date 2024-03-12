using System.ComponentModel.DataAnnotations;

namespace VideoRentalApplication.Models
{
    public class Customer
    {
        [Key]
        [MaxLength(10)]
        public int CustomerId { get; set; }

        [Required]
        public required string Name { get; set; }

        public int? Age { get; set; }

        [MaxLength(10)]
        public required string Gender { get; set; }

        [Required]
        public decimal PhoneNumber { get; set; }

        [MaxLength(30)]
        public required string EmailId { get; set; }
        public required ICollection<Rental> Rental { get; set; }
        //public ICollection<Return> Return { get; set; }


    }
   
}
