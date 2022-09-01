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

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Phonenumber = 0738450197, Name = "Simon Eliasson", City = "Kinna", PersonId = 1 });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Phonenumber = 0709952132, Name = "Janne Karlsson", City = "Göteborg", PersonId = 2 });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Phonenumber = 0782161234, Name = "Annie Svensson", City = "Borås", PersonId = 3 });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Phonenumber = 0741237894, Name = "Kalle Carlsson", City = "Malmö", PersonId = 4 });

        }

        //public DbSet<PersonModel> personModels { get; set; }

    }
}
