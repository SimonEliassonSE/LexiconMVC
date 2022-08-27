namespace LexiconMVC.Models.ViewModel
{
    public class PeopleViewModel
    {
        public static List<PersonModel> peopleRepository = null;

        public static List<PersonModel> displayList = new List<PersonModel>();

        public static int idCounter = 0;

        public PeopleViewModel()
        {

        }

        public void SetData()
        {
            if (peopleRepository == null)
            {
                peopleRepository = new List<PersonModel>();
                peopleRepository.Add(new PersonModel()
                {
                    PersonId = setId(),
                    Name = "Jörgen",
                    Phonenumber = 0738779922,
                    City = "Borås"
                });


                peopleRepository.Add(new PersonModel()
                {
                    PersonId = setId(),
                    Name = "Karin",
                    Phonenumber = 0739214321,
                    City = "Göteborg"
                });


                peopleRepository.Add(new PersonModel()
                {
                    PersonId = setId(),
                    Name = "Sallim",
                    Phonenumber = 0642749357,
                    City = "Kungsbacka"
                });

            }
        }
        public int setId()
        {
            int x = idCounter;
            idCounter++;
            return x;
            
           
        }

        public void Delete(int DeleteId)
        {
            if (peopleRepository.Count > 0)
                peopleRepository.Remove(peopleRepository.FirstOrDefault(t => t.PersonId == DeleteId));
        }

        public void Add(string NewName, int NewPhonenumber, string NewCity)
        {
            int NewId = setId();
            peopleRepository.Add(new PersonModel() { PersonId = NewId, Name = NewName, Phonenumber = NewPhonenumber, City = NewCity });
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
            for(int i = 0; i < peopleRepository.Count; i++)
            {
                if(peopleRepository[i].Name.Contains(SearchObject) || peopleRepository[i].City.Contains(SearchObject))
                {
                    displayList.Clear();
                }
            }               

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
