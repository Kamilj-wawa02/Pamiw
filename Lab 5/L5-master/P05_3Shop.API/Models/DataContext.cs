using Microsoft.EntityFrameworkCore;
using P06Shop.Shared.Library;
using P07Shop.DataSeeder;

namespace P05Shop.API.Models
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // fluent api 
            modelBuilder.Entity<Book>()
                .Property(p => p.Barcode)
                .IsRequired()
                .HasMaxLength(12);

            modelBuilder.Entity<Book>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Book>()
                .Property(p => p.Author)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Book>()
             .Property(p => p.Price)
             .HasColumnType("decimal(8,2)");

            // data seed 

            modelBuilder.Entity<Book>().HasData(BookSeeder.GenerateBookData());
        }
    }
}
// instalacja dotnet ef 
//dotnet tool install --global dotnet-ef

// aktualizacja 
//dotnet tool update --global dotnet-ef

// dotnet ef migrations add [nazwa_migracji]
// dotnet ef database update 


// cofniecie migraji niezaplikowanych 
//dotnet ef migrations remove