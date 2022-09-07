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
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Languages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Country>().HasData(new Country { CountryCode = "+46", CountryName = "Sweden", Continent = "Europe" });
            modelbuilder.Entity<Country>().HasData(new Country { CountryCode = "+47", CountryName = "Norway", Continent = "Europe" });
            modelbuilder.Entity<Country>().HasData(new Country { CountryCode = "+1", CountryName = "USA", Continent = "North America" });
            modelbuilder.Entity<Country>().HasData(new Country { CountryCode = "+52", CountryName = "Mexico", Continent = "South America" });
            modelbuilder.Entity<Country>().HasData(new Country { CountryCode = "+82", CountryName = "Japan", Continent = "Asia" });
            modelbuilder.Entity<Country>().HasData(new Country { CountryCode = "+61", CountryName = "Australia", Continent = "Australia" });

            modelbuilder.Entity<Language>().HasData(new Language { LanguageName = "Swedish", LanguageShortName = "SWE" });
            modelbuilder.Entity<Language>().HasData(new Language { LanguageName = "Japanese", LanguageShortName = "JAP" });
            modelbuilder.Entity<Language>().HasData(new Language { LanguageName = "Norwegian", LanguageShortName = "NOR" });
            modelbuilder.Entity<Language>().HasData(new Language { LanguageName = "Australian", LanguageShortName = "AUS" });
            modelbuilder.Entity<Language>().HasData(new Language { LanguageName = "Mexican", LanguageShortName = "MEX" });
            modelbuilder.Entity<Language>().HasData(new Language { LanguageName = "English", LanguageShortName = "USA" });

            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "41672", CityName = "Gothenburg", CountryID = "+46" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "50632", CityName = "Borås", CountryID = "+46" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "0010", CityName = "Oslo", CountryID = "+47" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "78613", CityName = "Austin", CountryID = "+1" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "22000", CityName = "Tijuana", CountryID = "+52" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "100", CityName = "Tokyo", CountryID = "+82" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "3000", CityName = "Melbourne", CountryID = "+61" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "60601", CityName = "Chicago", CountryID = "+1" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "602", CityName = "Kyoto", CountryID = "+82" });
            modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "5005", CityName = "Bergen", CountryID = "+47" });

            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Phonenumber = 0738450197, Name = "Simon Eliasson", SSN = "196103058877", CityID = "41672" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Phonenumber = 0709952132, Name = "Janne Karlsson", SSN = "198309067744", CityID = "50632" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Phonenumber = 0782161234, Name = "Annie Svensson", SSN = "199901023366", CityID = "50632" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Phonenumber = 0741237894, Name = "Kalle Carlsson", SSN = "200509012541", CityID = "100" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Phonenumber = 0738660102, Name = "Andy Hjert", SSN = "2001-11-31-8952", CityID = "3000" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Phonenumber = 0759982251, Name = "Björn Bergman", SSN = "1978-01-01-3578", CityID = "100" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Phonenumber = 0761496378, Name = "Sara Strand", SSN = "1995-03-07-9898", CityID = "60601" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Phonenumber = 0778852211, Name = "Frida Svensson", SSN = "1969-08-01-7487", CityID = "602" });


            modelbuilder.Entity<PersonModel>()
                .HasMany(l => l.LanguagesList)
                .WithMany(p => p.PeopleList)
                .UsingEntity(j => j.HasData(new { PeopleListSSN = "2001-11-31-8952", LanguagesListLanguageName = "Mexican" }));

            modelbuilder.Entity<PersonModel>()
                .HasMany(l => l.LanguagesList)
                .WithMany(p => p.PeopleList)
                .UsingEntity(j => j.HasData(new { PeopleListSSN = "2001-11-31-8952", LanguagesListLanguageName = "Japanese" }));

            modelbuilder.Entity<PersonModel>()
                .HasMany(l => l.LanguagesList)
                .WithMany(p => p.PeopleList)
                .UsingEntity(j => j.HasData(new { PeopleListSSN = "1995-03-07-9898", LanguagesListLanguageName = "Swedish" }));



        }        

    }
}
