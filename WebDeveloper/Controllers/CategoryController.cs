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
    [RoutePrefix("Category")]
    public class CategoryController : Controller
    {
        private CategoryData _categories = new CategoryData();

        [Route]
        public ActionResult Index()
        {
            return View(_categories.GetList());
        }

        public ActionResult Create()
        {
            return View(new Categories());
        }

        [HttpPost]
        public ActionResult Create(Categories categories)
        {
            /* Validación del lado del servidor - las llamadas a Requered */
            if (ModelState.IsValid)
            {
                _categories.Add(categories);
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("Edit/{id:int}")]
        public ActionResult Edit(int Id)
        {
            return View(_categories.GetCategoryById(Id));
        }

        [HttpPost]
        public ActionResult Edit(Categories categories)
        {
            /* Validación del lado del servidor - las llamadas a Requered */
            if (ModelState.IsValid)
            {
                _categories.Update(categories);
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("Delete/{id:int}")]
        public ActionResult Delete(int Id)
        {
            var categories = _categories.GetCategoryById(Id);
            if (categories == null)
                return RedirectToAction("Index");
            else
                return View(categories);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var categories = _categories.GetCategoryById(id);
            if (categories != null)
            {
                if (_categories.Delete(categories) > 0)
                    return RedirectToAction("Index");
            }
            return View(categories);
        }
    }
}
