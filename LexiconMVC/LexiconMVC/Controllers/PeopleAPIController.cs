using Microsoft.AspNetCore.Mvc;
using LexiconMVC.Data;
using LexiconMVC.Models;
using LexiconMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LexiconMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleAPIController : ControllerBase
    {
        readonly ApplicationDbContext _context;


        public PeopleAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<PeopleAPIController>
        [HttpGet]
        public List<Person> Get()
        {
            //PeopleViewModel pvm = new PeopleViewModel();
            //pvm.PeopleList = _context.People.ToList();
            var person = _context.People.ToList();
            //List<Person> personList = new List<Person>();
            //personList = person.ToList();

            return person;
        }

        // GET api/<PeopleAPIController>/5
        [HttpGet("{id}")]
        public List<Person> Get(int id)
        {

            var person = _context.People.FirstOrDefault(x => x.Id == id);
            List<Person> personList = new List<Person>();
            personList.Add(person);
            //return $"{person.Id} {person.Name} {person.Phonenumber} {person.CityId}";
     
            return personList;
        }

        // POST api/<PeopleAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
            //List<string> values = new List<string>();
            //values.Add(value);

        }

        // PUT api/<PeopleAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PeopleAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
