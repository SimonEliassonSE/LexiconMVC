namespace LexiconMVC.Models
{
    public class PersonModel
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public int Phonenumber { get; set; }
        public string? City { get; set; }

        public PersonModel()
        {

        }

        public PersonModel(int id, string name, int phonenumber, string city)
        {
            Id = id;
            Name = name;
            Phonenumber = phonenumber;
            City = city;
        }

    }
}
