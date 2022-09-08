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
                    LanguageName = language.LanguageName,
                    LanguageShortName = language.LanguageShortName,

                });
            }


            return View(allUsers);

        }

        public IActionResult AddLanguageToPerson ()
        {
            ViewBag.Persons = new SelectList(_context.Persons, "SSN", "Name");
            ViewBag.Languages = new SelectList(_context.Languages, "LanguageName", "LanguageName");



            return View();
        }

        [HttpPost]
        public IActionResult AddLanguageToPerson (string ssn, string languagename)
        {
            var person = _context.Persons.FirstOrDefault(x => x.SSN == ssn);
            var language = _context.Languages.FirstOrDefault(x => x.LanguageName == languagename);
            
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
