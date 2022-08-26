namespace LexiconMVC.Models.ViewModel
{
    public class PeopleViewModel
    {
        public static List<PersonModel> peopleRepository = null;

        public static List<PersonModel> displayList = new List<PersonModel>();
        public void SetData()
        {
            if (peopleRepository == null)
            {
                peopleRepository = new List<PersonModel>();
                peopleRepository.Add(new PersonModel()
                {
                    Id = 0,
                    Name = "Jörgen",
                    Phonenumber = 0738779922,
                    City = "Borås"
                });


                peopleRepository.Add(new PersonModel()
                {
                    Id = peopleRepository.Count,
                    Name = "Karin",
                    Phonenumber = 0739214321,
                    City = "Göteborg"
                });


                peopleRepository.Add(new PersonModel()
                {
                    Id = peopleRepository.Count,
                    Name = "Sallim",
                    Phonenumber = 0642749357,
                    City = "Kungsbacka"
                });

            }
        }

        public void Delete(int DeleteId)
        {
            if (peopleRepository.Count > 0)
                peopleRepository.Remove(peopleRepository.FirstOrDefault(t => t.Id == DeleteId));
        }

        public void Add(int NewId, string NewName, int NewPhonenumber, string NewCity)
        {
            peopleRepository.Add(new PersonModel() { Id = NewId, Name = NewName, Phonenumber = NewPhonenumber, City = NewCity });
        }

        public static void GetListOfPeople()
        {
            for (int i = 0; i < peopleRepository.Count; i++)
            {
                displayList.Add(peopleRepository[i]);
            }
        }

        public static void RetriveSearch(string SearchObject)
        {
            foreach (var user in peopleRepository)
            {
                if (user.Name.Contains(SearchObject) || user.City.Contains(SearchObject))
                {
                    displayList.Add(user);
                }
            }
        }
    }
}
