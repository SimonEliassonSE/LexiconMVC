using Microsoft.AspNetCore.Mvc;
using LexiconMVC.Models;
using LexiconMVC.Models.ViewModel;

namespace LexiconMVC.Controllers
{
    public class PeopleController : Controller
    {

        public ViewResult Index()
        {
            PeopleViewModel model = new PeopleViewModel();
            model.SetData();

            PeopleViewModel.displayList.Clear();
            PeopleViewModel.GetListOfPeople();

            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();

            return View(createPersonViewModel);
        }
        // Följande 3 (Find, Add & Delete) ActionResults skall finnas i min dataContainer (som skall vara en model? tror jag)
        [HttpGet]
        public ActionResult FindUsers (string SearchObject)
        {
            if(SearchObject != null)
            {
                PeopleViewModel.displayList.Clear();
                PeopleViewModel.RetriveSearch(SearchObject);
            }

            return View("Index");
        }

        public ActionResult DeleteFromList(int DeleteId)
        {
            PeopleViewModel model = new PeopleViewModel();
            model.Delete(DeleteId);
            return RedirectToAction("Index");
        }

        public ActionResult AddToList(int NewId, string NewName, int NewPhonenumber, string NewCity) 
        {
            PeopleViewModel model = new PeopleViewModel();
            if(NewPhonenumber != 0) 
            { 
            model.Add(NewId, NewName, NewPhonenumber, NewCity);
            }
            return RedirectToAction("Index");
        }

    }
}
