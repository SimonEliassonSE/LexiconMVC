using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.Models
{
    public class PersonModel
    {

        [Key]
        public int PersonId { get; set; }
        [Required]
        public string? Name { get; set; }
        public int Phonenumber { get; set; }
        [Required]
        public string? City { get; set; }



        public PersonModel()
        {

        }

        public PersonModel(int id, string name, int phonenumber, string city)
        {
            PersonId = id;
            Name = name;
            Phonenumber = phonenumber;
            City = city;
        }

    }
}
