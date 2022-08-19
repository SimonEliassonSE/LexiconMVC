﻿using LexiconMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LexiconMVC.Controllers
{
    public class DoctorController : Controller
    {
               

        public IActionResult FeverCheck()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(float fever) // Must corelate to the name that is requering the variable 
                                                     // <input type="number" name="fever" />
        {
            ViewBag.Message = DoctorModel.FeverCheck(fever);
            return View();
        }

        //public IActionResult SetSession() 
        ////{
        //Random random = new Random();
        //int rInt = random.Next(0, 100);
        //    HttpContext.Session.SetInt32("session", rInt);
        //    ViewBag.Message = rInt;

        //    return View();
        //}


        public IActionResult SetSession() 
        {
            Random random = new Random();
            int rInt = random.Next(0, 100);
            HttpContext.Session.SetInt32("Session", rInt);
            return View();
        }

        [HttpPost]
        public IActionResult SetSession(int input)
        {

            ViewBag.Message = DoctorModel.CheckNumber(input);
            
            return View();
        }

        public IActionResult GetSession()
        {
            ViewBag.Message = HttpContext.Session.GetInt32("Session");
            return View();
        }


    }


}
