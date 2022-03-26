using Manager.Contacts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace UniversitieManagemantSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentManager _departmentManager;

        public DepartmentController(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
            ViewBag.title = "Student Department";
        }

        // GET: DepartmentController
        public ActionResult DepartmentList()
        {
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
            return View(department);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentModel department)
        {
            if (ModelState.IsValid)
            {
                //try
                //{
                    bool isAdd = _departmentManager.Add(department);
                    if (isAdd)
                    {
                        return RedirectToAction(nameof(DepartmentList));
                    }
                //}
                //catch (Exception ex)
                //{
                //    ModelState.AddModelError("customerror", CustomDataSaveError);
                //}
            }

            return View(department);
        }

        //    // GET: DepartmentController/Edit/5
        //    public ActionResult Edit(int id)
        //    {
        //        return View();
        //    }

        //    // POST: DepartmentController/Edit/5
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit(int id, IFormCollection collection)
        //    {
        //        try
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }

        //    // GET: DepartmentController/Delete/5
        //    public ActionResult Delete(int id)
        //    {
        //        return View();
        //    }

        //    // POST: DepartmentController/Delete/5
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Delete(int id, IFormCollection collection)
        //    {
        //        try
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
    }
}
