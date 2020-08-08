using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Services;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            if (WebApiApplication.LOGED_IN)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult SignOut(object sender, EventArgs e)
        {
            WebApiApplication.LOGED_IN = false;
            return RedirectToAction("Index", "Home");
        }
    }
}
