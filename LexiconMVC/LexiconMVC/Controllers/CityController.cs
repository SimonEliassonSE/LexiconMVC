using LexiconMVC.Data;
using LexiconMVC.ViewModels;
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

            var citydata = from city in _context.Cities select city;        

            List<CityViewModel> allUsers = new List<CityViewModel>();

            foreach (var city in citydata)
            {
                allUsers.Add(new CityViewModel()
                {
                    CityPostalCode = city.CityPostalCode,
                    CityName = city.CityName,
                    CountryID = city.CountryID

                });
            }


            return View(allUsers);
        }

        public IActionResult AddPersonToCity()
        {
                      

            ViewBag.Persons = new SelectList(_context.Persons, "SSN", "Name");
            ViewBag.Cities = new SelectList(_context.Cities, "CityPostalCode", "CityName");


            var peopleWithCitys = from city in _context.Cities
                                  from people in _context.Persons
                                  where city.CityPostalCode == people.CityID
                                  select new
                                  {
                                      personSSN = people.SSN,
                                      personName = people.Name,
                                      personPhonenumber = people.Phonenumber,
                                      personCity = city.CityName

                                  };

            var peopleWithoutCitys =
                                  from people in _context.Persons
                                  where people.CityID == null
                                  select new
                                  {
                                      personSSN = people.SSN,
                                      personName = people.Name,
                                      personPhonenumber = people.Phonenumber,
                                      personCity = "No City Added Yet!"

                                  };


            List<CityViewModel> allUsers = new List<CityViewModel>();

            foreach (var person in peopleWithCitys)
            {
                allUsers.Add(new CityViewModel()
                {
                    SSN = person.personSSN,
                    Name = person.personName,
                    Phonenumber = person.personPhonenumber,
                    CityName = person.personCity

                });
            }


            foreach (var person in peopleWithoutCitys)
            {
                allUsers.Add(new CityViewModel()
                {
                    SSN = person.personSSN,
                    Name = person.personName,
                    Phonenumber = person.personPhonenumber,
                    CityName = person.personCity

                });
            }

            return View(allUsers);

        }

        [HttpPost]
        public IActionResult AddPersonToCity(string ssn, string citypostalcode)
        {
            var person = _context.Persons.FirstOrDefault(x => x.SSN == ssn);
            var city = _context.Cities.FirstOrDefault(x => x.CityPostalCode == citypostalcode);

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
