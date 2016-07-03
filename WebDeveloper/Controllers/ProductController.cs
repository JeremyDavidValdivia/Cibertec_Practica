using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;

namespace WebDeveloper.Controllers
{
    public class ProductController : Controller
    {
        private ProductData _product = new ProductData();

        // GET: Product
        public ActionResult Index()
        {
            var product = new ProductData();
            return View(_product.GetList());
        }

        public ActionResult Create()
        {
            return View(new Products());
        }

        [HttpPost]
        public ActionResult Create(Products product)
        {
            /* Validación del lado del servidor - las llamadas a Requered */
            if (ModelState.IsValid)
            {
                _product.Add(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {
            return View(_product.GetProductById(Id));
        }

        [HttpPost]
        public ActionResult Edit(Products product)
        {
            /* Validación del lado del servidor - las llamadas a Requered */
            if (ModelState.IsValid)
            {
                _product.Update(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int Id)
        {
            var product = _product.GetProductById(Id);
            if (product == null)
                return RedirectToAction("Index");
            else
                return View(product);
        }

        [HttpPost]
        public ActionResult Delete(Products product)
        {
            if (_product.Delete(product) > 0)
                return RedirectToAction("Index");
            return View(product);
        }
    }
}