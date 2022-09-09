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
                    Id = city.Id,
                    CityName = city.CityName,
                    CountryId = city.CountryId

                });
            }


            return View(allUsers);
        }

        public IActionResult AddPersonToCity()
        {


            ViewBag.People = new SelectList(_context.People, "Id", "Name");
            ViewBag.Cities = new SelectList(_context.Cities, "Id", "CityName");

            // Där man skapar person måste det finnas en dropDown SelectList med namn som sedan säger där namn = city.Id person.CityId add city.Id
            var peopleWithCitys = from city in _context.Cities
                                  from person in _context.People
                                  where city.Id == person.CityId
                                  select new
                                  {
                                      personId = person.Id,
                                      personName = person.Name,
                                      personPhonenumber = person.Phonenumber,
                                      personCity = city.CityName

                                  };




            List<CityViewModel> allUsers = new List<CityViewModel>();

            foreach (var person in peopleWithCitys)
            {
                allUsers.Add(new CityViewModel()
                {
                    PersonId = person.personId,
                    PersonName = person.personName,
                    Phonenumber = person.personPhonenumber,
                    CityName = person.personCity

                });
            }

            return View(allUsers);

        }

        [HttpPost]
        public IActionResult AddPersonToCity(int personid, int cityid)
        {
            var person = _context.People.FirstOrDefault(x => x.Id == personid);
            var city = _context.Cities.FirstOrDefault(x => x.Id == cityid);

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
