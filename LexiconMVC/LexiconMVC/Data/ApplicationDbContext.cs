using LexiconMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LexiconMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<City> cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);


            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Phonenumber = 0738450197, Name = "Simon Eliasson", SSN = "196103058877" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Phonenumber = 0709952132, Name = "Janne Karlsson", SSN = "198309067744" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Phonenumber = 0782161234, Name = "Annie Svensson", SSN = "199901023366" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Phonenumber = 0741237894, Name = "Kalle Carlsson", SSN = "200509012541" });

            modelbuilder.Entity<Country>().HasData(new Country { CountryCode = "+46", CountryName = "Sweden", Continent = "Europe" });
            modelbuilder.Entity<Country>().HasData(new Country { CountryCode = "+47", CountryName = "Norway", Continent = "Europe" });
            modelbuilder.Entity<Country>().HasData(new Country { CountryCode = "+1", CountryName = "USA", Continent = "North America" });
            modelbuilder.Entity<Country>().HasData(new Country { CountryCode = "+52", CountryName = "Mexico", Continent = "South America" });
            modelbuilder.Entity<Country>().HasData(new Country { CountryCode = "+82", CountryName = "Japan", Continent = "Asia" });
            modelbuilder.Entity<Country>().HasData(new Country { CountryCode = "+61", CountryName = "Australia", Continent = "Australia" });

            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "41672", CityName = "Gothenburg" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "50632", CityName = "Borås" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "0010", CityName = "Oslo" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "78613", CityName = "Austin" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "22000", CityName = "Tijuana" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "100", CityName = "Tokyo" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "3000", CityName = "Melbourne" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "60601", CityName = "Chicago" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "602", CityName = "Kyoto" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "5005", CityName = "Bergen" });


        }

        //public DbSet<PersonModel> personModels { get; set; }

    }
}
