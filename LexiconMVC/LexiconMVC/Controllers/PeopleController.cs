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
            //var query =       from person in _context.Persons
            //                  where person.Name == SearchObject || person.City.CityPostalCode == SearchObject
            //                  select person;

            //var query = from person in _context.Persons
            //            join city in _context.cities on person equals city.CityPostalCode
            //            where person.City.CityPostalCode == city.CityPostalCode
            //            select new { Faculty = fac, SemesterText = sem.SemesterText };

            List<PersonModel> listOfPeople = _context.Persons.ToList();
            List<City> listOfCities = _context.cities.ToList();
            //var Cities = _context.cities.FirstOrDefault(x => x.CityPostalCode == listOfPeople);
            List<CreatePersonViewModel> allUsers = new();

            for (int i = 0; i < listOfPeople.Count; i++)
            {
                
                //var city = _context.cities.FirstOrDefault(x => x.CityPostalCode == _context;

                allUsers.Add(new CreatePersonViewModel()
                {
                    SSN = listOfPeople[i].SSN,
                    Name = listOfPeople[i].Name,
                    Phonenumber = listOfPeople[i].Phonenumber,
                    //City = listOfCities[i].CityName 
                    City = listOfPeople[i].City
                });

            }

            return View(allUsers);

            //return View(_context.Persons.ToList());

        }
 

        public IActionResult FindUser(string SearchObject)
        {

            var querySearch = from person in _context.Persons
                              where person.Name == SearchObject || person.City.CityPostalCode == SearchObject
                              select person;

            List<CreatePersonViewModel> specificUser = new();

            foreach (var user in querySearch)
            {
                specificUser.Add(new CreatePersonViewModel()
                {
                    SSN = user.SSN,
                    Name = user.Name,
                    Phonenumber = user.Phonenumber,
                    City = user.City,
                });
            }

            return View("Index", specificUser);

          
        }




        public ActionResult DeleteFromList(string DeleteId)
        {

            var person = _context.Persons.FirstOrDefault(x => x.SSN == DeleteId);

            _context.Persons.Remove(person);
            _context.SaveChanges();

            return RedirectToAction("Index");



        }

        
        public ActionResult AddToList(string NewSSN, string NewName, int NewPhonenumber, string NewCity) 
        {
            ViewBag.Persons = new SelectList(_context.Persons, "SSN", "Name");
            ViewBag.cities = new SelectList(_context.cities, "CityPostalCode", "CityName");

            PersonModel model = new PersonModel();  
            
            model.SSN = NewSSN;
            model.Name = NewName;
            model.Phonenumber = NewPhonenumber;
            //model.City = NewCity;

            if (ModelState.IsValid)
            {              
                _context.Persons.Add(model);
                _context.SaveChanges();
            }

        return RedirectToAction("Index");

            //PeopleViewModel model = new PeopleViewModel();
            //if(NewPhonenumber != 0) 
            //{ 
            //model.Add(NewName, NewPhonenumber, NewCity);
            //}
            //return RedirectToAction("Index");
        }
        
        public IActionResult AddCityToPerson()
        {

            return RedirectToAction("AddPersonToCity", "City");
        }
       

    }
}
