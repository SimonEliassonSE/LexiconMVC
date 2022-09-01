using LexiconMVC.Data;
using LexiconMVC.Models;
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
            
            return View();
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
