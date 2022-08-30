namespace LexiconMVC.Models.ViewModel
{
    public class CreatePersonViewModel
    {
 
        public PersonModel? PersonModel { get; set; }
        public PeopleViewModel? PeopleViewModel { get; set; }      

        public int PersonId { get; set; }
        public string? Name { get; set; }
        public int Phonenumber { get; set; }
        public string? City { get; set; }


        public CreatePersonViewModel()
        {

        }
        public CreatePersonViewModel(int id,string name, int phonenumber, string city)
        {
            PersonId = id;
            Name = name;
            Phonenumber = phonenumber;
            City = city;
           
        }
    }
}
