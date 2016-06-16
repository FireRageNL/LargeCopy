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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogOff()
        {
            Session["UserID"] = null;
            Session["Admin"] = null;
            Session["Email"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}