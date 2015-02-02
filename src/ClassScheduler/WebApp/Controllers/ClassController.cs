using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Orleans.Samples.ClassScheduler.WebApp.Models;

namespace Orleans.Samples.ClassScheduler.WebApp.Controllers
{
    public class ClassController : Controller
    {
        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id)) return View();

            var classView = new ClassViewModel()
            {
                Id = new Guid(id),
                Name = "Calculus 101",
                Subject = "MAT",
                Teacher = "John Smith",
                ClassSize = 5
            };
            return View(classView);
        }

        public ActionResult Create()
        {
            return View(new ClassViewModel() {Id = Guid.NewGuid()});
        }

        [HttpPost]
        public ActionResult Create(ClassViewModel viewModel)
        {
            return RedirectToAction("Index", "Class", new { id = viewModel.Id});
        }

        public ActionResult Register()
        {
            return View(new RegistrationViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel registraion)
        {
            return RedirectToAction("Index", new {id = registraion.ClassId.ToString()});
        }
    }
}