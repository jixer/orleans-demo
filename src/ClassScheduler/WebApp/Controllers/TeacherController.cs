using System;
using System.Web.Mvc;
using Orleans.Samples.ClassScheduler.WebApp.Models;

namespace Orleans.Samples.ClassScheduler.WebApp.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index(string teacherId)
        {
            var teacher = new TeacherViewModel()
            {
                Id = new Guid(teacherId),
                FirstName = "John",
                LastName = "Smith"
            };
            return View(teacher);
        }

        public ActionResult Create()
        {
            return View(new TeacherViewModel() {Id = Guid.NewGuid()});
        }

        [HttpPost]
        public ActionResult Create(TeacherViewModel teacher)
        {
            return RedirectToAction("Index", new {teacherId = teacher.Id.ToString()});
        }
    }
}