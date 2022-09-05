using LexiconMVC.Data;
using LexiconMVC.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LexiconMVC.Controllers
{
    public class LanguageController : Controller
    {

        readonly ApplicationDbContext _context;

        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var peopleWithLanguage = from people in _context.Persons
            //                         from languages in _context.Languages
            //                         where people.SSN == languages.PersonModel.SSN
            //                         select new
            //                         {
            //                             personSSN = people.SSN,
            //                             personName = people.Name,
            //                             languages = languages.LanguageName,
            //                         };

            //var peopleWithOutLanguage = from people in _context.Persons
            //                         from languages in _context.Languages
            //                         where people.SSN != languages.PersonModel.SSN
            //                         select new
            //                         {
            //                             personSSN = people.SSN,
            //                             personName = people.Name,
            //                             languages = "No language added yet!"
            //                         };


            //List<CreatePersonViewModel> allUsers = new List<CreatePersonViewModel>();

            //foreach (var person in peopleWithLanguage)
            //{
            //    allUsers.Add(new CreatePersonViewModel()
            //    {
            //        SSN = person.SSN,
            //        Name = person.Name,
            //        LanguageName = person.LanguageName, 
            //    });
            //}

            //foreach (var person in peopleWithOutLanguage)
            //{
            //    allUsers.Add(new CreatePersonViewModel()
            //    {
            //        SSN = person.SSN,
            //        Name = person.Name,
            //        LanguageName = person.LanguageName,
            //    });
            //}

            return View(/*allUsers*/);
        }

        public IActionResult AddLanguageToPerson ()
        {
            ViewBag.Persons = new SelectList(_context.Persons, "SSN", "Name");
            ViewBag.Languages = new SelectList(_context.Languages, "LanguageName", "LanguageName");

            //var peopleLanguageQuery = from people in _context.Persons
            //                          from language in _context.Languages
            //                          where 

            return View();
        }

        [HttpPost]
        public IActionResult AddLanguageToPerson (string ssn, string languagename)
        {
            var personX = _context.Persons.FirstOrDefault(x => x.SSN == ssn);
            var languageX = _context.Languages.FirstOrDefault(x => x.LanguageName == languagename);

            

            if (ModelState.IsValid )
            {
                

                languageX.PeopleList.Add(personX);
                _context.SaveChanges();
        
            }

            return RedirectToAction("AddLanguageToPerson");

        }

        public IActionResult ReturnToPeopleIndex()
        {

            return RedirectToAction("Index", "People");
        }

    }
}
