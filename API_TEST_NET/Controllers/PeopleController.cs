using API_TEST_NET.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_TEST_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController([FromKeyedServices("peopleService")] IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("all")]
        public List<People> getPeople() => Repository.People;

        [HttpGet("{id}")]
        public ActionResult<People> Get(int id) {
            var people = Repository.People.Find(p => p.Id == id);

            if(people == null)
            {
                return NotFound();
            }

            return Ok(people);
        }

        [HttpGet("search/{search}")]
        public List<People> Get(string search) => Repository.People.Where(p => p.Name.ToLower().Contains(search.ToLower())).ToList();

        [HttpPost]
        public IActionResult Add(People people)
        {
            if(!_peopleService.Validate(people))
            {
                return BadRequest();
            }

            Repository.People.Add(people);
            return NoContent();
        }

        [HttpGet("random")]
        public int Number() => new Random().Next(1000);
    }

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People()
            {
                Id = 1, Name = "Pedro", Birthdate = new DateTime(1990, 12, 3)
            },
            new People()
            {
                Id = 2, Name = "Maria", Birthdate = new DateTime(1990, 12, 3)
            },
            new People()
            {
                Id = 3, Name = "Jose", Birthdate = new DateTime(1990, 12, 3)
            }
        };
    }

    public class People
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
