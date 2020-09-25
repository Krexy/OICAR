using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
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
        //// GET: Registration
        //public ActionResult Index()
        //{

        //    return View();
        //}

        [HttpPost]
        public ActionResult Index(string url)
        {
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Register(string userName,string email,string pass,string pswRepeat)
        {

            WebUser user = new WebUser();
            user.Username = userName;
            user.Email = email;
            user.Pass = pass;

            if (!email.Contains("@") || !email.Contains("."))
            {
                ViewBag.Info = "E-Mail is not in the correct format";
                //Response.Cookies["lblInfo"].Value = "E-Mail is not in the correct format";
                //Response.Cookies["lblInfo"].Expires = DateTime.Now.AddMinutes(5);
                //return RedirectToAction("Registration", "Login");
            }

            //Provjera
            WebApiApplication.BackendPost<WebUser>(user, WebApiApplication.URL_REGISTRATION_PATH);

            return RedirectToAction("Index", "Login");
        }
    }
}