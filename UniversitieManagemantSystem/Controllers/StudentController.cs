using Manager.Contacts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System;

namespace UniversitieManagemantSystem.Controllers
{
    public class StudentController : Controller
    {
        private IStudentManager _studentManager;
        private IDepartmentManager _departmentManager;
        private string _CustomDataSaveError;

        public StudentController(IStudentManager studentManager, IDepartmentManager departmentManager)
        {
            _studentManager = studentManager;
            _departmentManager = departmentManager;
            _CustomDataSaveError = new ErrorController().DataSaveCustomError();
    }

        // GET: StudentControlar
        public ActionResult StudentList()
        {
            var student = _studentManager.GetAll();
            return View(student);
        }

        // GET: StudentControlar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            StudentModel studentModel = _studentManager.Get(id);
            if (studentModel == null)
            {
                return NotFound();
            }
            return View(studentModel);
        }

        // GET: StudentControlar/Create
        public ActionResult Create()
        {
            ViewBag.departments = new SelectList(_departmentManager.GetAll(), "Id", "DeptName");
            return View();
        }

        // POST: StudentControlar/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Name,DateOfBirth,DeptId")] StudentModel student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isAdd = _studentManager.Add(student);
                        if (isAdd)
                        {
                            return RedirectToAction(nameof(StudentList));
                        }
                        else
                        {
                            ModelState.AddModelError(nameof(StudentModel.DeptId), "Please select department");
                        }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("customerror", _CustomDataSaveError);
                }
            }
       
            ViewBag.departments = new SelectList(_departmentManager.GetAll(), "Id", "DeptName");
            return View(student);
        }

        //// GET: StudentControlar/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: StudentControlar/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: StudentControlar/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: StudentControlar/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
