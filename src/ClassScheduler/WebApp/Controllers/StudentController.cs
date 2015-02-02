using System;
using System.IO;
using System.Web.Mvc;
using Orleans.Host;
using Orleans.Samples.ClassScheduler.Data;
using Orleans.Samples.ClassScheduler.Gain.Interface;
using Orleans.Samples.ClassScheduler.WebApp.Helper;
using Orleans.Samples.ClassScheduler.WebApp.Models;

namespace Orleans.Samples.ClassScheduler.WebApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index(string id)
        {
            OrleansHelper.EnsureOrleansClientInitialized();

            Guid studentGuid = new Guid(id);
            var grain = GrainFactory.GetGrain<IStudent>(studentGuid);
            
            StudentInfo studentInfo = grain.GetInfo().Result;

            var student = new StudentViewModel()
            {
                Id = studentGuid,
                FirstName = studentInfo.FirstName,
                LastName = studentInfo.LastName
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
            OrleansHelper.EnsureOrleansClientInitialized();

            var grain = GrainFactory.GetGrain<IStudent>(student.Id);
            grain.SetName(student.FirstName, student.LastName);
            return RedirectToAction("Index", new { id = student.Id.ToString() });
        }
    }
}