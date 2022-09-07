using Microsoft.AspNetCore.Mvc;
using LexiconMVC.Models.ViewModel;
using LexiconMVC.Models;
using LexiconMVC.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                                  from people in _context.Persons
                                  where city.CityPostalCode == people.CityID
                                  select new 
                                  { 
                                      personSSN = people.SSN,
                                      personName = people.Name,
                                      personPhonenumber = people.Phonenumber,
                                      personCity = city.CityName
                                      
                                    };


            List<PeopleViewModel> allUsers = new List<PeopleViewModel>();

            foreach (var person in peopleWithCitys)
            {
                allUsers.Add(new PeopleViewModel()
                {
                    SSN = person.personSSN,
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
            var searchQueryNameHaveCity = from person in _context.Persons
                              from city in _context.Cities
                              where person.Name == SearchObject
                              where person.CityID == city.CityPostalCode

                              select new
                              {
                                  personName = person.Name,
                                  personSSN = person.SSN,
                                  personPhone = person.Phonenumber,
                                  personCity = city.CityName
                              };

            // Gets search done on City, if there is a person with cityPostalCode that match city.CityPostalCode we add it to the select
            var searchQueryCity = from person in _context.Persons
                                  from city in _context.Cities
                                  where city.CityName == SearchObject
                                  where person.CityID == city.CityPostalCode

                                  select new
                                  {
                                      personName = person.Name,
                                      personSSN = person.SSN,
                                      personPhone = person.Phonenumber,
                                      personCity = city.CityName
                                  };

            List <PeopleViewModel> newSearchDone = new List<PeopleViewModel>();

            foreach (var person in searchQueryNameHaveCity)
            {
                
                newSearchDone.Add(new PeopleViewModel()
                {

                    SSN = person.personSSN,
                    Name = person.personName,
                    Phonenumber = person.personPhone,
                    CityName = person.personCity
                });
            }
           
            foreach (var person in searchQueryCity)
            {

                newSearchDone.Add(new PeopleViewModel()
                {

                    SSN = person.personSSN,
                    Name = person.personName,
                    Phonenumber = person.personPhone,
                    CityName = person.personCity
                });

            }

            // If Searchbutton is "clicked" without input, we go back to index and display the default list
            if(SearchObject == null)
            {
                return RedirectToAction("Index");
            
            }

            return View("Index", newSearchDone);

        }




        public ActionResult DeleteFromList(string DeleteId)
        {

            var person = _context.Persons.FirstOrDefault(x => x.SSN == DeleteId);

            _context.Persons.Remove(person);
            _context.SaveChanges();

            return RedirectToAction("Index");



        }

        
        public ActionResult AddToList(string NewSSN, string NewName, int NewPhonenumber, string CityName) 
        {

            var checkCityName = from city in _context.Cities
                                select new
                                {
                                    cityId = city.CityPostalCode,
                                    cityName = city.CityName
                                };
            
            PersonModel model = new PersonModel();

            foreach (var city in checkCityName)
            {
                if(city.cityName == CityName)
                {
                    model.SSN = NewSSN;
                    model.Name = NewName;
                    model.Phonenumber = NewPhonenumber;
                    model.CityID = city.cityId;
                }
                else
                {
                    
                }
            }




            if (ModelState.IsValid)
            {              
                _context.Persons.Add(model);
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
