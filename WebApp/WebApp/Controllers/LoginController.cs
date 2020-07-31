using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            //return View("Home/Index",model);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel model, string returnUrl)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}