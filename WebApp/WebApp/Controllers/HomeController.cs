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

            if (WebApiApplication.LOGED_IN && name != null)
            {
                return View("RestaurantDetails", WebApiApplication.restaurants.Where(r => r.RestaurantName == name).FirstOrDefault());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult UpdateGrade(string RestaurantName) {

            string currentUser = Session["username"] as String;
            RestaurantModel model = WebApiApplication.restaurants.Where(r => r.RestaurantName == RestaurantName).FirstOrDefault();

            //List<Food> hrana = new List<Food>();
            //hrana.Add(new Food("hrana", new GradeSpread(1, 2, 3, 4, 5), 3.2, "hrana nema sliku"));
            //List<Wine> vina = new List<Wine>();
            //vina.Add(new Wine("vino", new GradeSpread(1, 2, 3, 4, 5), 3.2, "vino nema sliku"));
            //GradeSpread gradeSpread = new GradeSpread(1, 2, 3, 4, 5);
            //RestaurantModel restaurant = new RestaurantModel("TestRestaurant", "nema", hrana, vina, gradeSpread, "neki link");
            //WebUser user = new WebUser("testUser", "123", "email");
            RestaurantUserCombo restaurantUserCombo = new RestaurantUserCombo() { RestaurantModel = model, WebUser = currentUser };
            string path = ControllerContext.HttpContext.Server.MapPath("~/example.xml");

            WebApiApplication.BackendPostWithReturnTest<RestaurantUserCombo, List<RestaurantModel>>(restaurantUserCombo, path);

            return View("RestaurantDetails",model);
        }
    }
}
