using System;
using System.Web.Mvc;
using Orleans.Samples.ClassScheduler.WebApp.Models;

namespace Orleans.Samples.ClassScheduler.WebApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index(string studentId)
        {
            var student = new StudentViewModel()
            {
                Id = new Guid(studentId),
                FirstName = "Chris",
                LastName = "Myers"
            };
            return View(student);
        }

        public ActionResult Create()
        {
            return View(new StudentViewModel() { Id = Guid.NewGuid()});
        }

        [HttpPost]
        public ActionResult Create(StudentViewModel student)
        {
            return RedirectToAction("Index", new { studentId = student.Id.ToString() });
        }
    }
}