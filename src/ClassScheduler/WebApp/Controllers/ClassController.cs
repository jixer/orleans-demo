﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Orleans.Samples.ClassScheduler.Data;
using Orleans.Samples.ClassScheduler.Gain.Interface;
using Orleans.Samples.ClassScheduler.WebApp.Helper;
using Orleans.Samples.ClassScheduler.WebApp.Models;

namespace Orleans.Samples.ClassScheduler.WebApp.Controllers
{
    public class ClassController : Controller
    {
        public async Task<ActionResult> Index(string id)
        {
            if (string.IsNullOrEmpty(id)) return View();

            OrleansHelper.EnsureOrleansClientInitialized();

            Guid classGuid = new Guid(id);
            ICollegeClass grain = GrainFactory.GetGrain<ICollegeClass>(classGuid);

            ClassInfo classInfo = await grain.GetClassInfo();
            IList<IStudent> students = await grain.GetStudents();
            string[] studentNames = new string[0];
            if (students != null && students.Count > 0)
            {
                var studentNameTasks = new Task<string>[students.Count];
                for (int i = 0; i < students.Count; i++)
                {
                    studentNameTasks[i] = students[i].GetFullName();
                }

                studentNames = await Task.WhenAll(studentNameTasks);
            }

            ITeacher teacherGrain = GrainFactory.GetGrain<ITeacher>(classInfo.Teacher);
            string teacherName = await teacherGrain.GetFullName();

            var classView = new ClassViewModel()
            {
                Id = new Guid(id),
                Name = classInfo.Name,
                Subject = classInfo.Subject,
                Teacher = teacherName,
                ClassSize = studentNames.Length,
                Students = studentNames
            };
            return View(classView);
        }

        public ActionResult Create()
        {
            return View(new ClassViewModel() {Id = Guid.NewGuid()});
        }

        [HttpPost]
        public async Task<ActionResult> Create(ClassViewModel viewModel)
        {
            OrleansHelper.EnsureOrleansClientInitialized();
            ICollegeClass grain = GrainFactory.GetGrain<ICollegeClass>(viewModel.Id);
            grain.Configure(viewModel.Name, viewModel.Subject);
            await grain.AssignTeacher(new Guid(viewModel.Teacher));
            return RedirectToAction("Index", "Class", new { id = viewModel.Id});
        }

        public ActionResult Register()
        {
            return View(new RegistrationViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegistrationViewModel registration)
        {
            OrleansHelper.EnsureOrleansClientInitialized();

            ICollegeClass grain = GrainFactory.GetGrain<ICollegeClass>(registration.ClassId);
            IStudent studentGrain = GrainFactory.GetGrain<IStudent>(registration.StudentId);
            await grain.RegisterStudent(studentGrain);

            return RedirectToAction("Index", new {id = registration.ClassId.ToString()});
        }
    }
}