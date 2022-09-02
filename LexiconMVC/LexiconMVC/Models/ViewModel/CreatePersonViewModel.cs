namespace LexiconMVC.Models.ViewModel
{
    public class CreatePersonViewModel
    {
 
        public PersonModel? PersonModel { get; set; }
        public PeopleViewModel? PeopleViewModel { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }


        public string? SSN { get; set; }
        public string? Name { get; set; }
        public int Phonenumber { get; set; }

        public string CityPostalCode { get; set; }
        public string CityName { get; set; }

        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Continent { get; set; }
     


        public CreatePersonViewModel()
        {

        }
        public CreatePersonViewModel(string id, string name, int phonenumber)
        {
            SSN = id;
            Name = name;
            Phonenumber = phonenumber;
        }
        public CreatePersonViewModel(string id,string name, int phonenumber, string cityName)
        {
            SSN = id;
            Name = name;
            Phonenumber = phonenumber;
            CityName = cityName;

        }

        public CreatePersonViewModel(string countryCode, string countryName, string continent)
        {
            CountryCode = countryCode;
            CountryName = countryName;
            Continent = continent;
        }

        public CreatePersonViewModel(string cityName , string cityPostalCode)
        {
            CityName = cityName;
            CityPostalCode = cityPostalCode;
  
        }
    }
}
