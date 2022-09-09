using Microsoft.AspNetCore.Mvc;
using LexiconMVC.ViewModels;
using LexiconMVC.Models;
using LexiconMVC.Data;


namespace LexiconMVC.Controllers
{
    public class PeopleController : Controller
    {
        readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }




        public IActionResult Index()
        {

            var peopleWithCitys = from city in _context.Cities
                                  from people in _context.People
                                  where city.Id == people.CityId
                                  select new
                                  {
                                      personId = people.Id,
                                      personName = people.Name,
                                      personPhonenumber = people.Phonenumber,
                                      personCity = city.CityName

                                  };


            List<PersonViewModel> allUsers = new List<PersonViewModel>();

            foreach (var person in peopleWithCitys)
            {
                allUsers.Add(new PersonViewModel()
                {
                    Id = person.personId,
                    Name = person.personName,
                    Phonenumber = person.personPhonenumber,
                    CityName = person.personCity

                });
            }

            return View(allUsers);

        }


        public ActionResult FindUser(string SearchObject)
        {
            // Finds people with city's added to them. 
            var searchQueryNameHaveCity = from person in _context.People
                                          from city in _context.Cities
                                          where person.Name == SearchObject
                                          where person.CityId == city.Id

                                          select new
                                          {
                                              personName = person.Name,
                                              personId = person.Id,
                                              personPhone = person.Phonenumber,
                                              personCity = city.CityName
                                          };

            // Gets search done on City, if there is a person with cityPostalCode that match city.CityPostalCode we add it to the select
            var searchQueryCity = from person in _context.People
                                  from city in _context.Cities
                                  where city.CityName == SearchObject
                                  where person.CityId == city.Id

                                  select new
                                  {
                                      personName = person.Name,
                                      personId = person.Id,
                                      personPhone = person.Phonenumber,
                                      personCity = city.CityName
                                  };

            List<PersonViewModel> newSearchDone = new List<PersonViewModel>();

            foreach (var person in searchQueryNameHaveCity)
            {

                newSearchDone.Add(new PersonViewModel()
                {

                    Id = person.personId,
                    Name = person.personName,
                    Phonenumber = person.personPhone,
                    CityName = person.personCity
                });
            }

            foreach (var person in searchQueryCity)
            {

                newSearchDone.Add(new PersonViewModel()
                {

                    Id = person.personId,
                    Name = person.personName,
                    Phonenumber = person.personPhone,
                    CityName = person.personCity
                });

            }

            // If Searchbutton is "clicked" without input, we go back to index and display the default list
            if (SearchObject == null)
            {
                return RedirectToAction("Index");

            }

            return View("Index", newSearchDone);

        }




        public ActionResult DeleteFromList(int DeleteId)
        {

            var person = _context.People.FirstOrDefault(x => x.Id == DeleteId);

            _context.People.Remove(person);
            _context.SaveChanges();

            return RedirectToAction("Index");



        }

        // Tänk på att vi inte behöver använda NewId här. EF kommer skapa ett Id automatiskt åt oss.
        public ActionResult AddToList(string NewName, int NewPhonenumber, string CityName)
        {

            var checkCityName = from city in _context.Cities
                                select new
                                {
                                    cityId = city.Id,
                                    cityName = city.CityName
                                };

            Person model = new Person();

            foreach (var city in checkCityName)
            {
                if (city.cityName == CityName)
                {
                    model.Name = NewName;
                    model.Phonenumber = NewPhonenumber;
                    model.CityId = city.cityId;
                }
            }

            if (ModelState.IsValid)
            {
                _context.People.Add(model);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult CityIndex()
        {

            return RedirectToAction("CityIndex", "City");
        }

        public IActionResult CountryIndex()
        {
            return RedirectToAction("CountryIndex", "Country");
        }

        public IActionResult LanguageIndex()
        {

            return RedirectToAction("LanguageIndex", "Language");
        }


    }
}
