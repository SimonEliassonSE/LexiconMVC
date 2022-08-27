namespace LexiconMVC.Models
{
    public class PersonModel
    {

        public int PersonId { get; set; }
        public string? Name { get; set; }
        public int Phonenumber { get; set; }
        public string? City { get; set; }

        public PersonModel()
        {

        }

        public PersonModel(int id, string name, int phonenumber, string city)
        {
            PersonId = id;
            Name = name;
            Phonenumber = phonenumber;
            City = city;
        }

    }
}
