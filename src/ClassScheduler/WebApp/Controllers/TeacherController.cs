using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Orleans.Samples.ClassScheduler.Data;
using Orleans.Samples.ClassScheduler.Gain.Interface;
using Orleans.Samples.ClassScheduler.WebApp.Helper;
using Orleans.Samples.ClassScheduler.WebApp.Models;

namespace Orleans.Samples.ClassScheduler.WebApp.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public async Task<ActionResult> Index(string id)
        {
            OrleansHelper.EnsureOrleansClientInitialized();

            Guid teacherGuid = new Guid(id);

            ITeacher grain = GrainFactory.GetGrain<ITeacher>(teacherGuid);
            TeacherInfo teacherInfo = await grain.GetInfo();

            var teacher = new TeacherViewModel()
            {
                Id = teacherGuid,
                FirstName = teacherInfo.FirstName,
                LastName = teacherInfo.LastName
            };
            return View(teacher);
        }

        public ActionResult Create()
        {
            return View(new TeacherViewModel() {Id = Guid.NewGuid()});
        }

        [HttpPost]
        public async Task<ActionResult> Create(TeacherViewModel teacher)
        {
            OrleansHelper.EnsureOrleansClientInitialized();

            var grain = GrainFactory.GetGrain<ITeacher>(teacher.Id);
            await grain.SetName(teacher.FirstName, teacher.LastName);
            
            return RedirectToAction("Index", new {id = teacher.Id.ToString()});
        }
    }
}