using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VideoRentalApplication.Models;



public class VideoRentalDbContext : DbContext
{
    public VideoRentalDbContext(DbContextOptions<VideoRentalDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Rental> Rental { get; set; }
    //public DbSet<Return> Return { get; set; }
    //public object Returns { get; internal set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer"); // Explicitly map to table name (optional)
            entity.HasKey(e => e.CustomerId);

            entity.Property(e => e.CustomerId)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength(); // Adjust data type and length as needed

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255); // Adjust length as needed

            entity.Property(e => e.Age); // Adjust data type if needed

            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsFixedLength(); // Adjust data type and length as needed

            entity.Property(e => e.PhoneNumber)
                .IsRequired(); // Adjust data type if needed

            entity.Property(e => e.EmailId)
                .HasMaxLength(30)
                .IsFixedLength(); // Adjust data type and length as needed
        });
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId);

            entity.Property(e => e.MovieId)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength(); // Assuming MovieId is a fixed-length character string

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Description)
                .HasMaxLength(int.MaxValue); // Use int.MaxValue for NVARCHAR(MAX)

            entity.Property(e => e.Genre)
                .HasMaxLength(10)
                .IsFixedLength(); // Assuming Genre is a fixed-length character string

            entity.Property(e => e.ReleaseDate);

            entity.Property(e => e.Language)
                .HasMaxLength(50)
                .IsFixedLength(); // Assuming Language is a fixed-length character string
        });
        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.RentalId);

            entity.Property(e => e.RentalId)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength(); // Assuming RentalId is a fixed-length character string

            entity.Property(e => e.MovieId)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength(); // Assuming MovieId is a fixed-length character string

            entity.Property(e => e.CustomerId)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength(); // Assuming CustomerId is a fixed-length character string

            entity.Property(e => e.RentalDate)
                .IsRequired();

            entity.Property(e => e.ReturnDate)
                .IsRequired();

            entity.Property(e => e.RentalFee)
                .HasColumnType("numeric");

            entity.Property(e => e.LateFee)
                .HasColumnType("numeric");

            entity.Property(e => e.ReturnId);

            entity.HasOne(d => d.Customer)
                .WithMany(p => p.Rental)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull); // Optional: Set OnDelete behavior

            entity.HasOne(d => d.Movie)
                .WithMany(p => p.Rental)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull); // Optional: Set OnDelete behavior
        });
        

        // Similar configurations for Movies, Rentals, and RentalReturns...

        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Customer)
            .WithMany()
            .HasForeignKey(r => r.CustomerId);

        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Movie)
            .WithMany()
            .HasForeignKey(r => r.MovieId);

        //modelBuilder.Entity<Rental>()
            //.HasOne(r => r.Return)
            //.WithOne(rr => rr.Rental)
            //.HasForeignKey<Return>(rr => r.RentalId);

        

        // Similar foreign key configurations for RentalReturns...
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }


}