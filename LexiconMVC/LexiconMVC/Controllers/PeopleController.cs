using Microsoft.AspNetCore.Mvc;
using LexiconMVC.Models.ViewModel;

namespace LexiconMVC.Controllers
{
    public class PeopleController : Controller
    {

        public ViewResult Index(string SearchObject)
        {
            PeopleViewModel model = new PeopleViewModel();
            //model.SetData();
            if (PeopleViewModel.peopleRepository == null) 
            {
                model.SetData();
            }
            // added if(searchObject) 
            // PeopleViewModel.displayList.Clear();
            // PeopleViewModel.GetListOfPeople();

            if (SearchObject == null)
            {
                PeopleViewModel.displayList.Clear();
                PeopleViewModel.GetListOfPeople();
            }

            else if(SearchObject != null)
            {              
                model.RetriveSearch(SearchObject);
            }


            //List<CreatePersonViewModel> allUsers = new();
            //{
            //    for (int i = 0; i < PeopleViewModel.displayList.Count; i++)
            //    {
            //        new CreatePersonViewModel (PeopleViewModel.displayList[i].PersonId,
            //                                   PeopleViewModel.displayList[i].Name,
            //                                   PeopleViewModel.displayList[i].Phonenumber,
            //                                   PeopleViewModel.displayList[i].City);
            //    }

            //}

            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();

            return View(createPersonViewModel);
        }
        // Följande 3 (Find, Add & Delete) ActionResults skall finnas i min dataContainer (som skall vara en model? tror jag)


        //public ActionResult FindUser (string SearchObject)
        //{
        //    PeopleViewModel model = new PeopleViewModel();         
        //    model.RetriveSearch(SearchObject);              

        //    //return PartialView("_people", model);
        //    return RedirectToAction("index");
        //}

        public ActionResult DeleteFromList(int DeleteId)
        {
            PeopleViewModel model = new PeopleViewModel();
            model.Delete(DeleteId);
            return RedirectToAction("index");

        }

        public ActionResult AddToList(string NewName, int NewPhonenumber, string NewCity) 
        {
            PeopleViewModel model = new PeopleViewModel();
            if(NewPhonenumber != 0) 
            { 
            model.Add(NewName, NewPhonenumber, NewCity);
            }
            return RedirectToAction("Index");
        }

    }
}
