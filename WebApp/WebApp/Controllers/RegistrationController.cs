using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string url)
        {
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Register(WebUser user)
        {
            //Provjera
            WebApiApplication.BackendPost<WebUser>(user, WebApiApplication.URL_REGISTRATION_PATH);

            return RedirectToAction("Index", "Login");
        }
    }
}