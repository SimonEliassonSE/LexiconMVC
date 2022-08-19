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


            if(fever > 0)

                if (fever >= 37.9) // feber över 37.8 referens https://www.1177.se/sjukdomar--besvar/infektioner/feber/feber/#:~:text=Den%20normala%20kroppstemperaturen%20hos%20vuxna,dig%20svag%20och%20lite%20yr.
                    ViewBag.Message = "You got a fever! Get some rest & drink plenty of fluides to get better soon!";
                else if (fever < 36)
                    ViewBag.Message = "You got hypothermia! Take a hot shower and rest under some blankets to increase your body temperature!";                
                else
                    ViewBag.Message = "Your temperature are normal!";
                    return View();
            

        }
    
    }


}
