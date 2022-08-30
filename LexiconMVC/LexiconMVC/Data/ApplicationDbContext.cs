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

        //public DbSet<PersonModel> personModels { get; set; }

    }
}
