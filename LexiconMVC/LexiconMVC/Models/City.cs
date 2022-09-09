using System.ComponentModel.DataAnnotations;
namespace LexiconMVC.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; } 
        //public string CityPostalCode { get; set; }
        public string CityName { get; set; }
        // istället för CountryID string
        public int CountryId { get; set; }
        //public string CountryID { get; set; }
        public Country Country { get; set; }
        public List<Person> People { get; set; } = new List<Person>();

    }
}
