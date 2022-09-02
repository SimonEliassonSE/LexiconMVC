using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.Models
{
    public class PersonModel
    {
        // Remove database and change PersonId to SSN and Phonenumber to string, Remove both Required aswell.
        [Key]
        public string? SSN { get; set; }

     
        public string? Name { get; set; }

        public int Phonenumber { get; set; }

        //public City City { get; set; }
           

        public City? City { get; set; } 

    }
}
