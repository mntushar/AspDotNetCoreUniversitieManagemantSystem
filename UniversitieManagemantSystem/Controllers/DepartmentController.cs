using AutoMapper;
using Manager.Contacts;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using UniversitieManagemantSystem.Models.Department;

namespace UniversitieManagemantSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentManager _departmentManager;
        private string _CustomDataSaveError;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentManager departmentManager, IMapper mapper)
        {
            _departmentManager = departmentManager;
            _mapper = mapper;
            _CustomDataSaveError = new ErrorController().DataSaveCustomError();
        }

        // GET: DepartmentController
        public ActionResult DepartmentList()
        {
            //ViewBag.title = "Student Department";
            var AllDept = _departmentManager.GetAll();
            return View(AllDept);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var department = _departmentManager.Get(id);
            if (department == null)
            {
                return NotFound();
            }
            var departmentVm = _mapper.Map<DepartmentDetailsMv>(department);
            return View(departmentVm);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,DeptName")] DepartmentModel department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isAdd = _departmentManager.Add(department);
                    if (isAdd)
                    {
                        return RedirectToAction(nameof(DepartmentList));
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("customerror", _CustomDataSaveError);
                }
            }

            return View(department);
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            DepartmentModel department = _departmentManager.Get(id);
            if (department == null)
            {
                return NotFound();
            }
            return View("Create", department);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,DeptName")] DepartmentModel department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isEdit = _departmentManager.Update(department);
                    if (isEdit) return RedirectToAction(nameof(DepartmentList));

                }
                catch (Exception)
                {
                    ModelState.AddModelError("customerror", _CustomDataSaveError);
                }
            }
            return View("Create", department);
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            DepartmentModel department = _departmentManager.Get(id);
            if (department == null)
            {
                return NotFound();
            }
            var departmentMv = _mapper.Map<DepartmentDetailsMv>(department);
            return View("Details", departmentMv);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            DepartmentModel department = _departmentManager.Get(id);
            if (department != null)
            {
                try
                {
                    bool isDelete = _departmentManager.Remove(department);
                    if (isDelete) return RedirectToAction(nameof(DepartmentList));

                }
                catch (Exception)
                {
                    ModelState.AddModelError("customerror", _CustomDataSaveError);
                }
            }
            return BadRequest();
        }
    }
}
