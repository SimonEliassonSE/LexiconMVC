using System.ComponentModel.DataAnnotations;
namespace LexiconMVC.Models
{
    public class City
    {
        [Key]
        public string CityPostalCode { get; set; }
        public string CityName { get; set; }
        public string CountryID { get; set; }
        public Country Country { get; set; }
        public List<Person> People { get; set; } = new List<Person>();

    }
}
