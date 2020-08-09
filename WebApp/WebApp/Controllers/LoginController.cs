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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (Response.Cookies["Username"].Value == null)
            {
                Response.Cookies["Username"].Value = String.Empty;
                Response.Cookies["Password"].Value = String.Empty;
            }
                return View("Login");
        }
        [HttpPost]
        public ActionResult Login(Login user,string checkbox)
        {
            //user se spaja preko name taga
            System.Diagnostics.Debug.WriteLine(user.Username);
            System.Diagnostics.Debug.WriteLine(user.Password);

            WebApiApplication.restaurants = WebApiApplication.BackendPostWithReturn<Login,List<RestaurantModel>>(user, WebApiApplication.URL_LOGIN_PATH);

            RestaurantModel restaurant1 = new RestaurantModel("drugi", "nema", "neka hrana", "neka vina", 2.3, "neki link");
            RestaurantModel restaurant2 = new RestaurantModel("treci", "nema", "neka hrana", "neka vina", 4.3, "neki link");
            RestaurantModel restaurant3 = new RestaurantModel("cetvrti", "nema", "neka hrana", "neka vina", 1.6, "neki link");
            RestaurantModel restaurant4 = new RestaurantModel("peti", "nema", "neka hrana", "neka vina", 4.7, "neki link");
            WebApiApplication.restaurants.Add(restaurant1);
            WebApiApplication.restaurants.Add(restaurant2);
            WebApiApplication.restaurants.Add(restaurant3);
            WebApiApplication.restaurants.Add(restaurant4);

            WebApiApplication.filteredRestaurants = WebApiApplication.restaurants;

            if (checkbox == "on")
            {
                Response.Cookies.Add(new HttpCookie("Username", user.Username));
                Response.Cookies.Add(new HttpCookie("Password", user.Password));
                Response.Cookies["Username"].Expires = DateTime.Now.AddMinutes(5);
                Response.Cookies["Password"].Expires = DateTime.Now.AddMinutes(5);
            }


            WebApiApplication.LOGED_IN = true;
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Registration()
        {
            return View("Registration");
        }
    }
}