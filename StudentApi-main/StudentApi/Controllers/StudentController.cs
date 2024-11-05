using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
        {
        private static List<Student> students = new List<Student>
       {
        new Student
        {
            Id = 1,
            Name = "miri",
            Tasks = new Task []
            {
                new Task
                {
                    Name = "ex1.page1",
                    Id = 1,
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    Subject = new Subject
                    {
                        Id = 1,
                        Name = "history",
                        Teacher = "ruti"
                    },
                    IsCompleted = true
                }
            }
        }
    };


        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var stu = students.FirstOrDefault(e => e.Id == id);
            if (stu == null)
                return NotFound();

            return stu;
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] Student s)
        {
            if (s == null)
            {
                return;
            }
            s.Id = students.Max(e => e.Id) + 1;
            students.Add(s);
        }

            // PUT api/<StudentController>/5
            [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student s)
        {
            var stu = students.FirstOrDefault(e => e.Id == id);
            if (stu == null)
            {
                return;
            }
            stu.Name = s.Name;
            stu.Id = s.Id;
            stu.Tasks = s.Tasks;
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var stu = students.FirstOrDefault(e => e.Id == id);
            if (stu == null)
            {
                return;
            }
            students.Remove(stu);
        }
    }
}