namespace LexiconMVC.Models.ViewModel
{
    public class CreatePersonViewModel
    {
 
        public PersonModel? PersonModel { get; set; }
        public PeopleViewModel? PeopleViewModel { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public Language Language { get; set; }


        public string? SSN { get; set; }
        public string? Name { get; set; }
        public int Phonenumber { get; set; }

        public string CityPostalCode { get; set; }
        public string CityName { get; set; }

        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Continent { get; set; }
        public string LanguageName { get; set; }
        public string LanguageShort { get; set; }
     


        public CreatePersonViewModel()
        {

        }

    }
}
