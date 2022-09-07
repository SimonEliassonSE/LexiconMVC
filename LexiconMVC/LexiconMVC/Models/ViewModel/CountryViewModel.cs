namespace LexiconMVC.Models.ViewModel
{
    public class CountryViewModel
    {
        public Country Country { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Continent { get; set; }

        public City City { get; set; }        
        public string CityName { get; set; }


    }
}
