using LexiconMVC.Data;
using LexiconMVC.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LexiconMVC.Controllers
{
    public class CityController : Controller
    {
        readonly ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult CityIndex()
        {
            //List<City> listOfCity = _context.cities.ToList();
            //List<CreatePersonViewModel> allUsers = new();
            //for (int i = 0; i < listOfCity.Count; i++)
            //{

            //    allUsers.Add(new CreatePersonViewModel()
            //    {
            //        CityName = listOfCity[i].CityName,
            //        CityPostalCode = listOfCity[i].CityPostalCode,                    
                    
            //    });

            //}

            return View();
        }

        public IActionResult AddPersonToCity()
        {
                      

            ViewBag.Persons = new SelectList(_context.Persons, "SSN", "Name");
            ViewBag.cities = new SelectList(_context.cities, "CityPostalCode", "CityName");


            var peopleWithCitys = from city in _context.cities
                                  from people in _context.Persons
                                  where city.CityPostalCode == people.City.CityPostalCode
                                  select new
                                  {
                                      personSSN = people.SSN,
                                      personName = people.Name,
                                      personPhonenumber = people.Phonenumber,
                                      personCity = city.CityName

                                  };

            var peopleWithoutCitys =
                                  from people in _context.Persons
                                  where people.City.CityPostalCode == null
                                  select new
                                  {
                                      personSSN = people.SSN,
                                      personName = people.Name,
                                      personPhonenumber = people.Phonenumber,

                                  };


            List<CreatePersonViewModel> allUsers = new List<CreatePersonViewModel>();

            foreach (var person in peopleWithCitys)
            {
                allUsers.Add(new CreatePersonViewModel()
                {
                    SSN = person.personSSN,
                    Name = person.personName,
                    Phonenumber = person.personPhonenumber,
                    CityName = person.personCity

                });
            }


            foreach (var person in peopleWithoutCitys)
            {
                allUsers.Add(new CreatePersonViewModel()
                {
                    SSN = person.personSSN,
                    Name = person.personName,
                    Phonenumber = person.personPhonenumber,
                    CityName = "No City Added Yet!"

                });
            }

            return View(allUsers);

        }

        [HttpPost]
        public IActionResult AddPersonToCity(string ssn, string citypostalcode)
        {
            var person = _context.Persons.FirstOrDefault(x => x.SSN == ssn);
            var city = _context.cities.FirstOrDefault(x => x.CityPostalCode == citypostalcode);

            if (ModelState.IsValid)
            {
                city.People.Add(person);
                _context.SaveChanges();
            }




                return RedirectToAction("AddPersonToCity");
        }


        public IActionResult ReturnToPeopleIndex()
        {

            return RedirectToAction("Index", "People");
        }

    }


}
