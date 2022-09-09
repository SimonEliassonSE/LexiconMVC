using LexiconMVC.Data;
using LexiconMVC.Models;
using LexiconMVC.ViewModels;
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


        public IActionResult LanguageIndex()
        {

            var languagedata = from language in _context.Languages select language;

            List<LanguageViewModel> allUsers = new List<LanguageViewModel>();

            foreach (var language in languagedata)
            {
                allUsers.Add(new LanguageViewModel()
                {
                    Id = language.Id,
                    LanguageName = language.LanguageName,
                    LanguageShortName = language.LanguageShortName,

                });
            }


            return View(allUsers);

        }

        public IActionResult AddLanguageToPerson()
        {
            ViewBag.People = new SelectList(_context.People, "Id", "Name");
            ViewBag.Languages = new SelectList(_context.Languages, "Id", "LanguageName");

             // Hur får man tag på many to many? ska man lägga till en prop i people och lang? 
            return View();
        }
        // Gå igenom LanguageController, views m.m sedan PersonController views osv....
        
        [HttpPost]
        public IActionResult AddLanguageToPerson(int ssn, int languagename)
        {
            var person = _context.People.FirstOrDefault(x => x.Id == ssn);
            var language = _context.Languages.FirstOrDefault(x => x.Id == languagename);

            if (ModelState.IsValid)
            {

                person.LanguagesList.Add(language);
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
