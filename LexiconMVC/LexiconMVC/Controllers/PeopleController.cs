using Microsoft.AspNetCore.Mvc;
using LexiconMVC.Models.ViewModel;
using System.Collections.Generic;

namespace LexiconMVC.Controllers
{
    public class PeopleController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            PeopleViewModel model = new PeopleViewModel();

            model.SetData();

            PeopleViewModel.displayList.Clear();
            PeopleViewModel.GetListOfPeople();


            List<CreatePersonViewModel> allUsers = new List<CreatePersonViewModel>();
            {
                for (int i = 0; i < PeopleViewModel.displayList.Count; i++)
                {
                    
                    allUsers.Add(new CreatePersonViewModel()
                    {
                        PersonId = PeopleViewModel.displayList[i].PersonId,
                        Name = PeopleViewModel.displayList[i].Name,
                        Phonenumber = PeopleViewModel.displayList[i].Phonenumber,
                        City = PeopleViewModel.displayList[i].City,  
                    });
                    
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

                    allUsers.Add(new CreatePersonViewModel()
                    {
                        PersonId = PeopleViewModel.displayList[i].PersonId,
                        Name = PeopleViewModel.displayList[i].Name,
                        Phonenumber = PeopleViewModel.displayList[i].Phonenumber,
                        City = PeopleViewModel.displayList[i].City,
                    });

                }

            }

            return View("Index", allUsers);

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

        public ActionResult GetListOfPeople()
        {
            PeopleViewModel model = new PeopleViewModel();

            model.SetData();

            PeopleViewModel.displayList.Clear();
            PeopleViewModel.GetListOfPeople();


            List<CreatePersonViewModel> allUsers = new();
            {
                for (int i = 0; i < PeopleViewModel.displayList.Count; i++)
                {

                    allUsers.Add(new CreatePersonViewModel()
                    {
                        PersonId = PeopleViewModel.displayList[i].PersonId,
                        Name = PeopleViewModel.displayList[i].Name,
                        Phonenumber = PeopleViewModel.displayList[i].Phonenumber,
                        City = PeopleViewModel.displayList[i].City,
                    });

                }                

            }
            return View("Index", allUsers);

        }

    }
}
