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

                    Id = country.Id,
                    CountryName = country.CountryName,
                    Continent = country.Continent,

                });
            }


            return View(allUsers);
        }

        // Update inte add.
        public IActionResult UpdateCityToCountryRelation()
        {


            ViewBag.Cities = new SelectList(_context.Cities, "Id", "CityName");
            ViewBag.Countries = new SelectList(_context.Countries, "Id", "CountryName");

            var countryQuery = from countries in _context.Countries
                               from cities in _context.Cities
                               where cities.CountryId == countries.Id
                               select new
                               {
                                   CountryId = countries.Id,
                                   CountryName = countries.CountryName,
                                   Contitent = countries.Continent,
                                   CityName = cities.CityName
                               };

            List<CountryViewModel> allUsers = new List<CountryViewModel>();

            foreach (var country in countryQuery)
            {
                allUsers.Add(new CountryViewModel()
                {

                    Id = country.CountryId,
                    CountryName = country.CountryName,
                    Continent = country.Contitent,
                    CityName = country.CityName


                });
            }

            return View(allUsers);

        }

        [HttpPost]
        public IActionResult UpdateCityToCountryRelation(int cityid, int countryid)
        {

            var country = _context.Countries.FirstOrDefault(c => c.Id == countryid);
            var city = _context.Cities.FirstOrDefault(c => c.Id == cityid);

            if(ModelState.IsValid)
            {
                country.Cities.Add(city);
                _context.SaveChanges();
            }

            //var city = _context.Cities.FirstOrDefault(x => x.Id == countryid);
            //var country = _context.Countries.FirstOrDefault(x => x.Id == cityid);

            //if (ModelState.IsValid)
            //{
            //    country.Cities.Add(city);
            //    _context.SaveChanges();
            //}

            return RedirectToAction("UpdateCityToCountryRelation");
        }

        public IActionResult ReturnToPeopleIndex()
        {

            return RedirectToAction("Index", "People");
        }
    }
}
