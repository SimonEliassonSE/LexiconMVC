using LexiconMVC.Models;


namespace LexiconMVC.ViewModels
{
    public class PersonViewModel
    {
        public Person People { get; set; }
        public string SSN { get; set; }

        public string Name { get; set; }

        public int Phonenumber { get; set; }


        public City City { get; set; }
        public string CityName { get; set; }
    }
}
