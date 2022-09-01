using Microsoft.AspNetCore.Mvc;
using LexiconMVC.Models.ViewModel;
using LexiconMVC.Models;
using LexiconMVC.Data;
using System.Collections.Generic;

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
            List<PersonModel> listOfPeople = _context.Persons.ToList();
            List<CreatePersonViewModel> allUsers = new();
            for (int i = 0; i < listOfPeople.Count; i++)
            {

                allUsers.Add(new CreatePersonViewModel()
                {
                    PersonId = listOfPeople[i].PersonId,
                    Name = listOfPeople[i].Name,
                    Phonenumber = listOfPeople[i].Phonenumber,
                    City = listOfPeople[i].City,
                });

            }

            return View(allUsers);

            //return View(_context.Persons.ToList());

        }
 

        public IActionResult FindUser(string SearchObject)
        {

            var querySearch = from person in _context.Persons
                              where person.Name == SearchObject || person.City == SearchObject
                              select person;

            List<CreatePersonViewModel> specificUser = new();

            foreach (var user in querySearch)
            {
                specificUser.Add(new CreatePersonViewModel()
                {
                    PersonId = user.PersonId,
                    Name = user.Name,
                    Phonenumber = user.Phonenumber,
                    City = user.City
                });
            }

                return View("Index", specificUser);

        }


        public ActionResult DeleteFromList(int DeleteId)
        {

            var person = _context.Persons.FirstOrDefault(x => x.PersonId == DeleteId);

            _context.Persons.Remove(person);
            _context.SaveChanges();

            return RedirectToAction("Index");

            //PeopleViewModel model = new PeopleViewModel();
            //model.Delete(DeleteId);
            //return RedirectToAction("index");

        }

        
        public ActionResult AddToList(/*int NewPersonId,*/ string NewName, int NewPhonenumber, string NewCity) 
        {

            
            PersonModel model = new PersonModel();  
            
                  
            model.Name = NewName;
            model.Phonenumber = NewPhonenumber;
            model.City = NewCity;

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
       

    }
}
