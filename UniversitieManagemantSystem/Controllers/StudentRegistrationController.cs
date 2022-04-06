using Manager.Contacts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversitieManagemantSystem.Controllers
{
    public class StudentRegistrationController : Controller
    {
        private IStudentRegristrationManager _studentRegristrationManager;

        public StudentRegistrationController(IStudentRegristrationManager studentRegristrationManager)
        {
            _studentRegristrationManager = studentRegristrationManager;
        }

        // GET: StudentRegristrationController
        public ActionResult RegList()
        {
            return View(_studentRegristrationManager.GetAll());
        }

        // GET: StudentRegristrationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentRegristrationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentRegristrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentRegristrationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentRegristrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentRegristrationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentRegristrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
