using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.ActionFilters;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;

namespace WebDeveloper.Controllers
{
    [LogActionFilter]
    [RoutePrefix("Order")]
    public class OrderController : Controller
    {
        private WebContextDb db = new WebContextDb();

        // GET: Orders
        [Route]
        public ActionResult Index()
        {
            var lOrders = db.lOrders.Include(p => p.Customers);
            return View(lOrders.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.lEmployees, "EmployeeID", "LastName");
            ViewBag.CustomerID = new SelectList(db.lCustomers, "CustomerID", "CompanyName");
            return View(new Orders());
        }

        [HttpPost]
        public ActionResult Create(Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.lOrders.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.lEmployees, "EmployeeID", "LastName", orders.EmployeeID);
            ViewBag.CustomerID = new SelectList(db.lCustomers, "CustomerID", "CompanyName", orders.CustomerID);
            return View(orders);

        }

        [Route("Edit/{id:int}")]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.lOrders.Find(Id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.lEmployees, "EmployeeID", "LastName", orders.EmployeeID);
            ViewBag.CustomerID = new SelectList(db.lCustomers, "CustomerID", "CompanyName", orders.CustomerID);
            return View(orders);
        }

        [HttpPost]
        public ActionResult Edit(Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.lOrders, "EmployeeID", "LastName", orders.EmployeeID);
            ViewBag.CustomerID = new SelectList(db.lOrders, "CustomerID", "CompanyName", orders.CustomerID);
            return View(orders);
        }

        [Route("Delete/{id:int}")]
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.lOrders.Find(Id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders orders = db.lOrders.Find(id);
            db.lOrders.Remove(orders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}