using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LargeCopies.Models;

namespace LargeCopies.Controllers
{
    public class HomeController : Controller
    {
        public static db data = new db();
        public ActionResult Index()
        {
            return View();
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

        public ActionResult dbtest()
        {
            bool test = data.dbtest();
            ViewData["dbcon"] = test;
            return View();
        }
    }
}