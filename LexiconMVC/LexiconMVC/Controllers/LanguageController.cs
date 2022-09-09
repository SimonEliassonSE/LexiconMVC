﻿using LexiconMVC.Data;
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


                });
            }


            return View(allUsers);

        }

        public IActionResult AddLanguageToPerson()
        {
            ViewBag.People = new SelectList(_context.People, "Id", "Name");
            ViewBag.Languages = new SelectList(_context.Languages, "Id", "LanguageName");

            
            return View();
        }

        
        [HttpPost]   
        public IActionResult AddLanguageToPerson(int personid, int languageid)
        {
            var person = _context.People.FirstOrDefault(x => x.Id == personid);
            var language = _context.Languages.FirstOrDefault(x => x.Id == languageid);

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
