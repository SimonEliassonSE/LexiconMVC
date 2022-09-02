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
            ViewBag.countries = new SelectList(_context.countries , "CountryCode", "CountryName");


            //var citiesWithCountry = from country in _context.countries
            //                        from city in _context.cities
            //                        where country.CountryCode == Country.CityPostalCode /*  city.CityPostalCode*/  /*city.CityPostalCode == people.City.CityPostalCode*/
            //                        select new
            //                        {
            //                            cityName = city.CityName,
            //                            countryName = country.CountryName,
            //                            countryCode = country.CountryCode,
            //                            countryContinent = country.Continent,


            //                        };

            //var citiesWithoutCountry =
            //                      from country in _context.countries
            //                      from city in _context.cities
            //                      where country.CountryCode != city.CityPostalCode  /*city.CityPostalCode == people.City.CityPostalCode*/
            //                      select new
            //                      {
            //                          cityName = city.CityName,
            //                                                      //countryCode = country.CountryCode,
            //                                                      //countryContinent = country.Continent,

            //                      };


            //List<CreatePersonViewModel> allUsers = new List<CreatePersonViewModel>();

            //foreach (var cities in citiesWithCountry)
            //{
            //    allUsers.Add(new CreatePersonViewModel()
            //    {
            //        CityName = cities.cityName,
            //        CountryName = cities.countryName,
            //        CountryCode = cities.countryCode,
            //        Continent = cities.countryContinent

            //    });
            //}


            //foreach (var cities in citiesWithoutCountry)
            //{
            //    allUsers.Add(new CreatePersonViewModel()
            //    {
            //        CityName = cities.cityName,
            //        CountryName = "Country Has Not Been Added Yet!",
            //        CountryCode = "  ",
            //        Continent = "  "

            //    });
            //}

            return View(/*allUsers*/);

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
