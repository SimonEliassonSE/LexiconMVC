using LexiconMVC.Models;

namespace LexiconMVC.ViewModels

{
    public class CityViewModel
    {
        public City City { get; set; }       
        public int Id { get; set; }
        //public string CityPostalCode { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        //public string CountryID { get; set; }
        public Person PersonModel { get; set; }
        public int PersonId { get; set; }

        public string PersonName { get; set; }

        public int Phonenumber { get; set; }
    }
}
