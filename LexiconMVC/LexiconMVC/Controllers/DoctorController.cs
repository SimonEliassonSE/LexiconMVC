using LexiconMVC.Models;
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
            

            if (HttpContext.Session.GetInt32("Session") != null) 
            {
                return View();
            }

            else
            {
                Random random = new Random();
                int rInt = random.Next(0, 101);
                HttpContext.Session.SetInt32("Session", rInt);
                return View();
            } 
            
            
        }

        // This aint perfect, but it dose match the input with my variabel in session and changes it if the geuss is correct. However work in progress still. 
        [HttpPost] 
        public IActionResult SetSession(int input)
        {

            if (HttpContext.Session.GetInt32("Session") == input) 
            { 
                ViewBag.Message = "Your geuss was [" + input + "], that was the correct geuss!";
                Random random = new Random();
                int rInt = random.Next(0, 101);
                HttpContext.Session.SetInt32("Session", rInt);               
            }

            else if (HttpContext.Session.GetInt32("Session") > input) 
            { 
                ViewBag.Message = "Your geuss was [" + input + "], that was to smal!";
            }

            else if(HttpContext.Session.GetInt32("Session") < input)
            { 
                ViewBag.Message = "Your geuss was [" + input + "], that was to big!";
            }

            return View();
        }

        public IActionResult GetSession()
        {
            ViewBag.Message = HttpContext.Session.GetInt32("Session");
            return View();
        }


    }


}
