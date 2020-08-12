using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
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
            if (WebApiApplication.FIRST_VISIT)
            {
                Response.Cookies.Add(new HttpCookie("English", "on"));
                Response.Cookies.Add(new HttpCookie("Croatian", "off"));
                Response.Cookies.Add(new HttpCookie("Toggle", "on"));
                Response.Cookies.Add(new HttpCookie("Language", "en"));
            }
            WebApiApplication.LOGED_IN = false;
            if (Response.Cookies["Username"].Value == null)
            {
                Response.Cookies["Username"].Value = String.Empty;
                Response.Cookies["Password"].Value = String.Empty;
            }
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(Login user, string checkbox)
        {
            //user se spaja preko name taga

            WebApiApplication.restaurants = WebApiApplication.BackendPostWithReturn<Login, List<RestaurantModel>>(user, WebApiApplication.URL_LOGIN_PATH);

            List<Food> hrana = new List<Food>();
            hrana.Add(new Food("hrana", new GradeSpread(1, 2, 3, 4, 5), 3.2, "hrana nema sliku"));
            List<Wine> vina = new List<Wine>();
            vina.Add(new Wine("vino", new GradeSpread(1, 2, 3, 4, 5), 3.2, "vino nema sliku"));

            RestaurantModel restaurant1 = new RestaurantModel("drugi", "nema", hrana, vina, new GradeSpread(1, 2, 3, 4, 5), "neki link");
            RestaurantModel restaurant2 = new RestaurantModel("treci", "nema", hrana, vina, new GradeSpread(1, 2, 3, 4, 5), "neki link");
            RestaurantModel restaurant3 = new RestaurantModel("cetvrti", "nema",hrana,vina, new GradeSpread(1, 2, 3, 4, 5), "neki link");
            RestaurantModel restaurant4 = new RestaurantModel("drugi", "nema", hrana, vina, new GradeSpread(1, 2, 3, 4, 5), "neki link");
            RestaurantModel restaurant5 = new RestaurantModel("drugi", "nema", hrana, vina, new GradeSpread(1, 2, 3, 4, 5), "neki link");
            RestaurantModel restaurant6 = new RestaurantModel("drugi", "nema", hrana, vina, new GradeSpread(1, 2, 3, 4, 5), "neki link");
            RestaurantModel restaurant7 = new RestaurantModel("drugi", "nema", hrana, vina, new GradeSpread(1, 2, 3, 4, 5), "neki link");
            RestaurantModel restaurant8 = new RestaurantModel("drugi", "nema", hrana, vina, new GradeSpread(1, 2, 3, 4, 5), "neki link");
            WebApiApplication.restaurants.Add(restaurant1);
            WebApiApplication.restaurants.Add(restaurant2);
            WebApiApplication.restaurants.Add(restaurant3);
            WebApiApplication.restaurants.Add(restaurant4);
            WebApiApplication.restaurants.Add(restaurant5);
            WebApiApplication.restaurants.Add(restaurant6);
            WebApiApplication.restaurants.Add(restaurant7);
            WebApiApplication.restaurants.Add(restaurant8);

            WebApiApplication.filteredRestaurants = WebApiApplication.restaurants;

            if (checkbox == "on")
            {
                Response.Cookies.Add(new HttpCookie("Username", user.Username));
                Response.Cookies.Add(new HttpCookie("Password", user.Password));
                Response.Cookies["Username"].Expires = DateTime.Now.AddMinutes(5);
                Response.Cookies["Password"].Expires = DateTime.Now.AddMinutes(5);

                //Response.Cookies["Username"].Value = user.Username;
                //Response.Cookies["Password"].Value = user.Password;
            }


            WebApiApplication.LOGED_IN = true;
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Registration()
        {
            return View("Registration");
        }
        [HttpPost]
        public ActionResult Language(string option)
        {
            if (option != null)
            {
                Response.Cookies["English"].Value = "on";
                Response.Cookies["Croatian"].Value = "off";
                Response.Cookies["Toggle"].Value = option;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                Response.Cookies["Language"].Value = "en";

            }
            else
            {
                Response.Cookies["English"].Value = "off";
                Response.Cookies["Croatian"].Value = "on";
                Response.Cookies["Toggle"].Value = String.Empty;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("hr");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr");
                Response.Cookies["Language"].Value = "hr";

            }
            WebApiApplication.FIRST_VISIT = false;
            //return RedirectToAction("Index", "Login");
            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}