using System.ComponentModel.DataAnnotations;
namespace LexiconMVC.Models
{
    public class City
    {
        [Key]
        public string CityPostalCode { get; set; }
        public string CityName { get; set; }
        //public Country Country { get; set; }
        // If you want to add this part you have 2 Comment out the seed in applicationData ore else build failed... 
        // Reverted latest migration with this added since i got Sql = Null reference
        public List<PersonModel> People { get; set; } = new List<PersonModel>();

    }
}
