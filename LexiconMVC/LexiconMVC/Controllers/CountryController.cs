using LexiconMVC.Data;
using LexiconMVC.ViewModels;
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

            var countrydata = from country in _context.Countries select country;

            List<CountryViewModel> allUsers = new List<CountryViewModel>();

            foreach (var country in countrydata)
            {
                allUsers.Add(new CountryViewModel()
                {
                
                    CountryCode = country.CountryCode,
                    CountryName = country.CountryName,
                    Continent = country.Continent,           

                });
            }


            return View(allUsers);
        }

        public IActionResult AddCityToCountry()
        {


            ViewBag.Cities = new SelectList(_context.Cities, "CityPostalCode", "CityName");
            ViewBag.Countries = new SelectList(_context.Countries, "CountryCode", "CountryName");

            var countryQuery = from countries in _context.Countries
                               from cities in _context.Cities
                               where cities.CountryID == countries.CountryCode
                               select new
                               {
                                   CountryCode = countries.CountryCode,
                                   CountryName = countries.CountryName,
                                   Contitent = countries.Continent,
                                   CityName = cities.CityName       
                               };

           List <CountryViewModel> allUsers = new List<CountryViewModel>();

            foreach (var country in countryQuery)
            {
                allUsers.Add(new CountryViewModel()
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

            var city = _context.Cities.FirstOrDefault(x => x.CityPostalCode == citypostalcode);
            var country = _context.Countries.FirstOrDefault(x => x.CountryCode == countrycode);

            if (ModelState.IsValid)
            {
                country.Cities.Add(city);
                _context.SaveChanges();
            }




            return RedirectToAction("AddCityToCountry");
        }

        public IActionResult ReturnToPeopleIndex()
        {

            return RedirectToAction("Index", "People");
        }
    }
}
