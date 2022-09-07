namespace LexiconMVC.Models.ViewModel
{
    public class PeopleViewModel
    {
        public PersonModel People { get; set; }
        public string? SSN { get; set; }

        public string? Name { get; set; }

        public int Phonenumber { get; set; }


        public City City { get; set; }
        public string CityName { get; set; }
    }
}
