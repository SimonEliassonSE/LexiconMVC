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

       
        public ActionResult FindUser(string SearchObject)
        {
            // Finds people with city's added to them. 
            var searchQueryNameHaveCity = from person in _context.Persons
                              from city in _context.cities
                              where person.Name == SearchObject
                              where city.CityPostalCode == person.City.CityPostalCode

                              select new
                              {
                                  personName = person.Name,
                                  personSSN = person.SSN,
                                  personPhone = person.Phonenumber,
                                  personCity = city.CityName
                              };
            // Gets people without a city added to them, sends out a default message that the person have no city asigned yet
            var searchQueryNameHasNoCity = from person in _context.Persons                                        
                                          where person.Name == SearchObject
                                          where person.City.CityPostalCode == null

                                           select new
                                          {
                                              personName = person.Name,
                                              personSSN = person.SSN,
                                              personPhone = person.Phonenumber,
                                              personCity = "No City Added Yet!"
                                           };
            // Gets search done on City, if there is a person with cityPostalCode that match city.CityPostalCode we add it to the select
            var searchQueryCity = from person in _context.Persons
                                  from city in _context.cities
                                  where city.CityName == SearchObject
                                  where person.City.CityPostalCode == city.CityPostalCode

                                  select new
                                  {
                                      personName = person.Name,
                                      personSSN = person.SSN,
                                      personPhone = person.Phonenumber,
                                      personCity = city.CityName
                                  };

            List < CreatePersonViewModel > newSearchDone = new List<CreatePersonViewModel>();

            foreach (var person in searchQueryNameHaveCity)
            {
                
                newSearchDone.Add(new CreatePersonViewModel()
                {

                    SSN = person.personSSN,
                    Name = person.personName,
                    Phonenumber = person.personPhone,
                    CityName = person.personCity
                });
            }

            foreach (var person in searchQueryNameHasNoCity)
            {

                newSearchDone.Add(new CreatePersonViewModel()
                {

                    SSN = person.personSSN,
                    Name = person.personName,
                    Phonenumber = person.personPhone,
                    CityName = person.personCity
                });

            }

           
            foreach (var person in searchQueryCity)
            {

                newSearchDone.Add(new CreatePersonViewModel()
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

        
        public ActionResult AddToList(string NewSSN, string NewName, int NewPhonenumber) 
        {

            PersonModel model = new PersonModel();

            model.SSN = NewSSN;
            model.Name = NewName;
            model.Phonenumber = NewPhonenumber;

            if (ModelState.IsValid)
            {              
                _context.Persons.Add(model);
                _context.SaveChanges();
            }

        return RedirectToAction("Index");
        }
        
        public IActionResult AddCityToPerson()
        {

            return RedirectToAction("AddPersonToCity", "City");
        }
       

    }
}
