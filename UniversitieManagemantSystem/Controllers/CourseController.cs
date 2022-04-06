using Manager.Contacts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversitieManagemantSystem.Controllers
{
    public class CourseController : Controller
    {
        private ICourseManager _courseManager;

        public CourseController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        // GET: CourseModels
        public ActionResult CourseList()
        {
            return View(_courseManager.GetAll());
        }

        // GET: CourseModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return BadRequest();
            var course = _courseManager.Get(id);
            if (course == null) return BadRequest();

            return View(course);
        }

        // GET: CourseModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Title,SeatCount,Fee")] CourseModel course)
        {
            if (ModelState.IsValid)
            {
                bool isAdd = _courseManager.Add(course);
                if (isAdd) return RedirectToAction(nameof(CourseList));
            }

            return View(course);
        }

        // GET: CourseModels/Edit/5
        // public ActionResult Edit(int id)
        // {
        //     return View();
        // }

        // POST: CourseModels/Edit/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Edit(int id, IFormCollection collection)
        // {
        //     try
        //     {
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         return View();
        //     }
        // }

        // GET: CourseModels/Delete/5
        // public ActionResult Delete(int id)
        // {
        //     return View();
        // }

        // POST: CourseModels/Delete/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Delete(int id, IFormCollection collection)
        // {
        //     try
        //     {
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         return View();
        //     }
        // }
    }
}
