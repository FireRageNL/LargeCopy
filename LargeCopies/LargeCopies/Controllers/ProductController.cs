using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LargeCopies.Models;

namespace LargeCopies.Controllers
{
    public class ProductController : Controller
    {
        private Productdb _database = new Productdb();
        public ActionResult CreateProduct()
        {
            if (Session.Count > 0)
            {
                if ((bool) Session["Admin"])
                {
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductModel model)
        {
            bool added = _database.AddProduct(model);

            if (added)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult CreateTheme()
        {
            if (Session.Count > 0)
            {
                if ((bool)Session["Admin"])
                {
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult CreateThemet(ProductModel model)
        {
            bool added = _database.AddTheme(model);
        
            if (added)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult Kleding()
        {
            return View();
        }

        public ActionResult Accesoires()
        {
            return View();
        }

        public ActionResult Broeken()
        {
            return View();
        }

        public ActionResult Schoenen()
        {
            return View();
        }

        public ActionResult Tops()
        {
            return View();
        }

        public ActionResult Figures()
        {
            return View();
        }

        public ActionResult Juwelen()
        {
            return View();
        }
    }
}
