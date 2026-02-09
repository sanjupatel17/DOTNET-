using Microsoft.AspNetCore.Mvc;
using Assignment7.Data;
using System.Linq;

namespace Assignment7.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = from s in _context.Students
               where s.Age == 23
               select s;

        return View(students.ToList());


        }
    }
}
