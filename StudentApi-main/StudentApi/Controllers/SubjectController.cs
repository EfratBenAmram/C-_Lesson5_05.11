using Microsoft.AspNetCore.Mvc;
using StudentApi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace subjectdentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {

        private static List<Subject> subjects = new List<Subject>
        {
            new Subject
            {
                Id = 1,
                Name = "Math",
                Teacher = "dina"
            },
            new Subject
            {
                Id = 2,
                Name = "English",
                Teacher = "Ruti"
            }
        };

        // GET: api/<subjectdentController>
        [HttpGet]
        public IEnumerable<Subject> Get()
        {
            return subjects;
        }

        // GET api/<subjectdentController>/5
        [HttpGet("{id}")]
        public ActionResult<Subject> Get(int id)
        {
            var subject = subjects.FirstOrDefault(e => e.Id == id);
            if (subject == null)
                return NotFound();

            return subject;
        }

        // POST api/<subjectdentController>
        [HttpPost]
        public void Post([FromBody] Subject s)
        {
            if (s == null)
            {
                return;
            }
            s.Id = subjects.Max(e => e.Id) + 1;
            subjects.Add(s);
        }

        // PUT api/<subjectdentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Subject s)
        {
            var subject = subjects.FirstOrDefault(e => e.Id == id);
            if (subject == null)
            {
                return;
            }
            subject.Name = s.Name;
            subject.Id = s.Id;
            subject.Teacher = s.Teacher;
        }

        // DELETE api/<subjectdentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var subject = subjects.FirstOrDefault(e => e.Id == id);
            if (subject == null)
            {
                return;
            }
            subjects.Remove(subject);
        }
    }
}