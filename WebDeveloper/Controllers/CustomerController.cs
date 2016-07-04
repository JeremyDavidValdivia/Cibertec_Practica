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
    [RoutePrefix("Customer")]
    public class CustomerController : Controller
    {
        private CustomerData _customers = new CustomerData();

        // GET: Product
        [Route]
        public ActionResult Index()
        {
            //var product = new CustomerData();
            return View(_customers.GetList());
        }

        public ActionResult Create()
        {
            return View(new Customers());
        }

        [HttpPost]
        public ActionResult Create(Customers customer)
        {
            /* Validación del lado del servidor - las llamadas a Requered */
            if (ModelState.IsValid)
            {
                _customers.Add(customer);
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("Edit/{id:int}")]
        public ActionResult Edit(int Id)
        {
            return View(_customers.GetCustomerById(Id));
        }

        [HttpPost]
        public ActionResult Edit(Customers customer)
        {
            /* Validación del lado del servidor - las llamadas a Requered */
            if (ModelState.IsValid)
            {
                _customers.Update(customer);
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("Delete/{id:int}")]
        public ActionResult Delete(int Id)
        {
            var customer = _customers.GetCustomerById(Id);
            if (customer == null)
                return RedirectToAction("Index");
            else
                return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var customers = _customers.GetCustomerById(id);
            if (customers != null)
            {
                if (_customers.Delete(customers) > 0)
                    return RedirectToAction("Index");
            }
            return View(customers);
        }
    }
}