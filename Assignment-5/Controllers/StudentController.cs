using Microsoft.AspNetCore.Mvc;
using Assignment_5.Models;
using System.Collections.Generic;

namespace Assignment_5.Controllers;

public class StudentController : Controller
{
    public IActionResult Index()
    {

        var student = new List<Student> 
        {

            new Student { Id = 1, Name = "Diya", Course = "IT", Age = 22 },
            new Student { Id = 2, Name = "Sanjay", Course = "IT", Age = 21 },
            new Student { Id = 3, Name = "Patel", Course = "IT", Age = 23 }
        }
        ;

        return View(student);
    }
}
