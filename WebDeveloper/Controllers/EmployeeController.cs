using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.ActionFilters;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;

namespace WebDeveloper.Controllers
{
    [LogActionFilter]
    [RoutePrefix("Employee")]
    public class EmployeeController : Controller
    {
        private EmployeeData _employees = new EmployeeData();

        [Route]
        public ActionResult Index()
        {
            return View(_employees.GetList());
        }

        public ActionResult Create()
        {
            return View(new Employees());
        }

        [HttpPost]
        public ActionResult Create(Employees employees)
        {
            /* Validación del lado del servidor - las llamadas a Requered */
            if (ModelState.IsValid)
            {
                _employees.Add(employees);
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("Edit/{id:int}")]
        public ActionResult Edit(int Id)
        {
            return View(_employees.GetEmployeeById(Id));
        }

        [HttpPost]
        public ActionResult Edit(Employees employees)
        {
            /* Validación del lado del servidor - las llamadas a Requered */
            if (ModelState.IsValid)
            {
                _employees.Update(employees);
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("Delete/{id:int}")]
        public ActionResult Delete(int Id)
        {
            var employees = _employees.GetEmployeeById(Id);
            if (employees == null)
                return RedirectToAction("Index");
            else
                return View(employees);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var employees = _employees.GetEmployeeById(id);
            if (employees != null)
            {
                if (_employees.Delete(employees) > 0)
                    return RedirectToAction("Index");
            }
            return View(employees);
        }
    }
}