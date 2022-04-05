using AutoMapper;
using Manager.Contacts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversitieManagemantSystem.Models.Student;

namespace UniversitieManagemantSystem.Controllers
{
    public class StudentController : Controller
    {
        private IStudentManager _studentManager;
        private IDepartmentManager _departmentManager;
        private string _CustomDataSaveError;
        private readonly IMapper _mapper;

        public StudentController(IStudentManager studentManager, IDepartmentManager departmentManager, IMapper mapper)
        {
            _studentManager = studentManager;
            _departmentManager = departmentManager;
            _mapper = mapper;
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
            StudentCreateMv stdent = new StudentCreateMv();
            List<SelectListItem> Departments = _departmentManager.GetAll().Select(d => new SelectListItem() 
            { 
                Value = d.Id.ToString(),
                Text = d.DeptName
            }).ToList();
            stdent.Departments = Departments;
            return View(stdent);
        }

        // POST: StudentControlar/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Name,DateOfBirth,DeptId")] StudentCreateMv student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var sudentModel = _mapper.Map<StudentModel>(student);
                    bool isAdd = _studentManager.Add(sudentModel);
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

            student.Departments = _departmentManager.GetAll().Select(d=> new SelectListItem() 
            { 
                Value = d.Id.ToString(),
                Text = d.DeptName
            }).ToList();
            return View(student);
        }

        // GET: StudentControlar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();
            var student = _studentManager.Get(id);
            if(student == null)
            {
                return NotFound();
            }
            var studentmv = _mapper.Map<StudentEditMv>(student);
            studentmv.Departments = _departmentManager.GetAll().Select(d => new SelectListItem()
            {
                Value = d.Id.ToString(),
                Text = d.DeptName
            }).ToList();
            return View(studentmv);
        }

        // POST: StudentControlar/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Name,DateOfBirth,DeptId")] StudentEditMv student)
        {
            if (ModelState.IsValid)
            {
                var studentModel = _mapper.Map<StudentModel>(student);
                if (studentModel == null) return BadRequest();
           
                bool isEdit = _studentManager.Update(studentModel);

                if (isEdit) return RedirectToAction(nameof(StudentList));
                else ModelState.AddModelError(nameof(StudentModel.DeptId), "Please select department"); 
            }
            student.Departments = _departmentManager.GetAll().Select(d => new SelectListItem()
            {
                Value = d.Id.ToString(),
                Text = d.DeptName
            }).ToList();
            return View(student);
        }

        // GET: StudentControlar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();
            StudentModel student = _studentManager.Get(id);
            return View("Details", student);
        }

        // POST: StudentControlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null) return BadRequest();
            StudentModel student = _studentManager.Get(id);
            if (student == null) return BadRequest();
            bool isDelete = _studentManager.Remove(student);
            if (isDelete) return RedirectToAction(nameof(StudentList));

            return BadRequest();
        }
    }
}
