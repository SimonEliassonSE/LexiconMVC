using Microsoft.AspNetCore.Mvc;
using LexiconMVC.Models.ViewModel;

namespace LexiconMVC.Controllers
{
    public class PeopleController : Controller
    {

        // GET: /<controller>/
        public ViewResult Index()
        {
            PeopleViewModel model = new PeopleViewModel();

                model.SetData();
                
                PeopleViewModel.displayList.Clear();
                PeopleViewModel.GetListOfPeople();
           

            List<CreatePersonViewModel> allUsers = new();
            {
                for (int i = 0; i < PeopleViewModel.displayList.Count; i++)
                {
                    new CreatePersonViewModel(PeopleViewModel.displayList[i].PersonId,
                                               PeopleViewModel.displayList[i].Name,
                                               PeopleViewModel.displayList[i].Phonenumber,
                                               PeopleViewModel.displayList[i].City);
                }

            }

            return View(allUsers);
        }
 

        public IActionResult FindUser(string SearchObject)
        {
            if(SearchObject != null)
            {            
            PeopleViewModel model = new PeopleViewModel();
            model.RetriveSearch(SearchObject);
            }

            List<CreatePersonViewModel> allUsers = new();
            allUsers.Clear();
            {
                for (int i = 0; i < PeopleViewModel.displayList.Count; i++)
                {
                    new CreatePersonViewModel(PeopleViewModel.displayList[i].PersonId,
                                               PeopleViewModel.displayList[i].Name,
                                               PeopleViewModel.displayList[i].Phonenumber,
                                               PeopleViewModel.displayList[i].City);
                }

            }


            return View("Index" , allUsers);

        }


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
