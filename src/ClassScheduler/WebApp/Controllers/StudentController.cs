using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index(string id)
        {
            OrleansHelper.EnsureOrleansClientInitialized();

            Guid studentGuid = new Guid(id);
            var grain = GrainFactory.GetGrain<IStudent>(studentGuid);

            StudentInfo studentInfo = await grain.GetInfo();
            IList<ICollegeClass> classGrains = await grain.GetClasses();
            string[] enrolledClasses = new string[0];
            if (classGrains != null && classGrains.Count > 0)
            {
                var nameTasks = new Task<string>[classGrains.Count];
                for (int i = 0; i < classGrains.Count; i++)
                {
                    nameTasks[i] = classGrains[i].GetName();
                }

                enrolledClasses = await Task.WhenAll(nameTasks);
            }

            var student = new StudentViewModel()
            {
                Id = studentGuid,
                FirstName = studentInfo.FirstName,
                LastName = studentInfo.LastName,
                Classes = enrolledClasses
            };
            return View(student);
        }

        public ActionResult Create()
        {
            return View(new StudentViewModel() { Id = Guid.NewGuid()});
        }

        [HttpPost]
        public async Task<ActionResult> Create(StudentViewModel student)
        {
            OrleansHelper.EnsureOrleansClientInitialized();

            var grain = GrainFactory.GetGrain<IStudent>(student.Id);
            await grain.SetName(student.FirstName, student.LastName);

            return RedirectToAction("Index", new { id = student.Id.ToString() });
        }
    }
}