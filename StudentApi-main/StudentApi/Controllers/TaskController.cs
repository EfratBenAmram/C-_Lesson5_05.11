using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
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

        private static List<Task> tasks = new List<Task>
        {
            new Task
            {
                Name = "ex2.page1",
                Id = 2,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Subject = subjects[0], 
                IsCompleted = false
            }
        };

        // GET: api/<teacherdentController>
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return tasks;
        }

        // GET api/<teacherdentController>/5
        [HttpGet("{id}")]
        public ActionResult<Task> Get(int id)
        {
            var Task = tasks.FirstOrDefault(e => e.Id == id);
            if (Task == null)
                return NotFound();

            return Task;
        }

        // POST api/<teacherdentController>
        [HttpPost]
        public void Post([FromBody] Task s)
        {
            if (s == null)
            {
                return;
            }
            s.Id = tasks.Max(e => e.Id) + 1;
            tasks.Add(s);
        }

        // PUT api/<teacherdentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Task s)
        {
            var Task = tasks.FirstOrDefault(e => e.Id == id);
            if (Task == null)
            {
                return;
            }
            Task.Name = s.Name;
            Task.Id = s.Id;
            Task.Date = s.Date; 
            Task.Subject = s.Subject;
        }

        // DELETE api/<teacherdentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Task = tasks.FirstOrDefault(e => e.Id == id);
            if (Task == null)
            {
                return;
            }
            tasks.Remove(Task);
        }

        // GET api/<TaskController>/completed
        [HttpGet("completed")]
        public IEnumerable<Task> GetCompletedTasks()
        {
            return tasks.Where(t => t.IsCompleted);
        }

        // GET api/<TaskController>/incompleted
        [HttpGet("incompleted")]
        public IEnumerable<Task> GetIncompletedTasks()
        {
            return tasks.Where(t => !t.IsCompleted);
        }

    }
}