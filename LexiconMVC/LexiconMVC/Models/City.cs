using System.ComponentModel.DataAnnotations;
namespace LexiconMVC.Models
{
    public class City
    {
        [Key]
        public string CityPostalCode { get; set; }
        public string CityName { get; set; }
        public List<PersonModel> People { get; set; } = new List<PersonModel>();

    }
}
