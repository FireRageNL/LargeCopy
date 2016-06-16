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
        private Themedb _themedb = new Themedb();
        public ActionResult CreateProduct()
        {
            if (Session["Admin"] != null)
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
            if (Session["Admin"] != null)
            {
                if ((bool)Session["Admin"])
                {
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult CreateTheme(ThemaModel model)
        {
            bool added = _themedb.AddTheme(model);
        
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
            List<ProductModel> model = _database.FetchProducts("Kleding");
            return View(model);
        }

        public ActionResult KledingDetails(int id)
        {
            ProductModel details = _database.GetProductDetails(id);
            return View(details);
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
