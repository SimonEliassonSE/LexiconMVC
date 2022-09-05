using LexiconMVC.Data;
using LexiconMVC.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LexiconMVC.Controllers
{
    public class CountryController : Controller
    {
        readonly ApplicationDbContext _context;

        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult CountryIndex()
        {
            return View();
        }

        public IActionResult AddCityToCountry()
        {


            ViewBag.cities = new SelectList(_context.cities, "CityPostalCode", "CityName");
            ViewBag.countries = new SelectList(_context.countries, "CountryCode", "CountryName");

            var countryQuery = from countries in _context.countries
                               from cities in _context.cities
                               where cities.CountryID == countries.CountryCode
                               select new
                               {
                                   CountryCode = countries.CountryCode,
                                   CountryName = countries.CountryName,
                                   Contitent = countries.Continent,
                                   CityName = cities.CityName       
                               };

           List < CreatePersonViewModel > allUsers = new List<CreatePersonViewModel>();

            foreach (var country in countryQuery)
            {
                allUsers.Add(new CreatePersonViewModel()
                {

                    CountryCode = country.CountryCode,
                    CountryName = country.CountryName,                     
                    Continent = country.Contitent,
                    CityName = country.CityName
                    

                });
            }

            return View(allUsers);

        }

        [HttpPost]
        public IActionResult AddCityToCountry(string citypostalcode, string countrycode)
        {

            var city = _context.cities.FirstOrDefault(x => x.CityPostalCode == citypostalcode);
            var country = _context.countries.FirstOrDefault(x => x.CountryCode == countrycode);

            if (ModelState.IsValid)
            {
                country.Cities.Add(city);
                _context.SaveChanges();
            }




            return RedirectToAction("AddCityToCountry");
        }
    }
}
