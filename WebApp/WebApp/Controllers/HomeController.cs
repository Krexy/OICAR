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
    [System.Web.Http.Authorize]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            ViewBag.Title = "FINE";
            if (Response.Cookies["Filter"].Value == null)
            {
                Response.Cookies["Filter"].Value = String.Empty;
                Response.Cookies["Filter"].Value = String.Empty;
            }
            if (WebApiApplication.LOGED_IN)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult SignOut()
        {
            WebApiApplication.LOGED_IN = false;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Terms()
        {
            return View("Terms");
        }

        public ActionResult FilterRestaurants(string filter)
        {
            WebApiApplication.filteredRestaurants = WebApiApplication.restaurants.Where(r => r.RestaurantName.Contains(filter)).ToList();
            Response.Cookies.Add(new HttpCookie("Filter", filter));
            Response.Cookies["Filter"].Expires = DateTime.Now.AddMinutes(5);
            return View("Index");
        }

        public ActionResult RestaurantDetails(string name)
        {

            if (WebApiApplication.LOGED_IN)
            {
                return View("RestaurantDetails", WebApiApplication.restaurants.Where(r => r.RestaurantName == name).FirstOrDefault());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
