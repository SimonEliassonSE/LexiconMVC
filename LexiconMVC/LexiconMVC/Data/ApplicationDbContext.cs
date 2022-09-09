﻿using LexiconMVC.Models;
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

        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Languages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            //modelbuilder.Entity<Country>().HasData(new Country { Id = 1, CountryName = "Sweden", Continent = "Europe" });
            //modelbuilder.Entity<Country>().HasData(new Country { Id = 2,CountryName = "Norway", Continent = "Europe" });
            //modelbuilder.Entity<Country>().HasData(new Country { Id = 3,CountryName = "USA", Continent = "North America" });
            //modelbuilder.Entity<Country>().HasData(new Country { Id = 4,CountryName = "Mexico", Continent = "South America" });
            //modelbuilder.Entity<Country>().HasData(new Country { Id = 5,CountryName = "Japan", Continent = "Asia" });
            //modelbuilder.Entity<Country>().HasData(new Country { Id = 6,CountryName = "Australia", Continent = "Australia" });

            //modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "41672", CityName = "Gothenburg", CountryID = "+46" });
            //modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "50632", CityName = "Borås", CountryID = "+46" });
            //modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "0010", CityName = "Oslo", CountryID = "+47" });
            //modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "78613", CityName = "Austin", CountryID = "+1" });
            //modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "22000", CityName = "Tijuana", CountryID = "+52" });
            //modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "100", CityName = "Tokyo", CountryID = "+82" });
            //modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "3000", CityName = "Melbourne", CountryID = "+61" });
            //modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "60601", CityName = "Chicago", CountryID = "+1" });
            //modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "602", CityName = "Kyoto", CountryID = "+82" });
            //modelbuilder.Entity<City>().HasData(new City { CityPostalCode = "5005", CityName = "Bergen", CountryID = "+47" });

            //modelbuilder.Entity<Person>().HasData(new Person { Phonenumber = 0738450197, Name = "Simon Eliasson", SSN = "1961-03-05-8877", CityID = "41672" });
            //modelbuilder.Entity<Person>().HasData(new Person { Phonenumber = 0709952132, Name = "Janne Karlsson", SSN = "198309067744", CityID = "50632" });
            //modelbuilder.Entity<Person>().HasData(new Person { Phonenumber = 0782161234, Name = "Annie Svensson", SSN = "199901023366", CityID = "50632" });
            //modelbuilder.Entity<Person>().HasData(new Person { Phonenumber = 0741237894, Name = "Kalle Carlsson", SSN = "200509012541", CityID = "100" });
            //modelbuilder.Entity<Person>().HasData(new Person { Phonenumber = 0738660102, Name = "Andy Hjert", SSN = "2001-11-31-8952", CityID = "3000" });
            //modelbuilder.Entity<Person>().HasData(new Person { Phonenumber = 0759982251, Name = "Björn Bergman", SSN = "1978-01-01-3578", CityID = "100" });
            //modelbuilder.Entity<Person>().HasData(new Person { Phonenumber = 0761496378, Name = "Sara Strand", SSN = "1995-03-07-9898", CityID = "60601" });
            //modelbuilder.Entity<Person>().HasData(new Person { Phonenumber = 0778852211, Name = "Frida Svensson", SSN = "1969-08-01-7487", CityID = "602" });
            //modelbuilder.Entity<Person>().HasData(new Person { Phonenumber = 0778852211, Name = "Andy Karlsson", SSN = "1972-01-03-7497", CityID = "602" });
            //modelbuilder.Entity<Person>().HasData(new Person { Phonenumber = 0778852211, Name = "Charlie Svensson", SSN = "1989-02-11-6387", CityID = "100" });

            //modelbuilder.Entity<Language>().HasData(new Language { LanguageName = "Swedish", LanguageShortName = "SWE" });
            //modelbuilder.Entity<Language>().HasData(new Language { LanguageName = "Japanese", LanguageShortName = "JAP" });
            //modelbuilder.Entity<Language>().HasData(new Language { LanguageName = "Norwegian", LanguageShortName = "NOR" });
            //modelbuilder.Entity<Language>().HasData(new Language { LanguageName = "Spanish", LanguageShortName = "SPA" });
            //modelbuilder.Entity<Language>().HasData(new Language { LanguageName = "English", LanguageShortName = "USA" });

            //modelbuilder.Entity<Person>()
            //    .HasMany(l => l.LanguagesList)
            //    .WithMany(p => p.PeopleList)
            //    .UsingEntity(j => j.HasData(new { PeopleListSSN = "1961-03-05-8877", LanguagesListLanguageName = "Swedish" }));

        }

    }
}
