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

            RestaurantsUserCombo combo = WebApiApplication.BackendPostWithReturn<Login, RestaurantsUserCombo>(user, WebApiApplication.URL_LOGIN_PATH);

            //string test = combo.WebUser.Username;

            if (combo.WebUser == null)
            {
                return View("Login");

            }
            WebApiApplication.restaurants = combo.RestaurantModels;

            Session["username"] = combo.WebUser.Username;
            if (combo.WebUser.VIDs == null)
            {
                Session["VIDs"] = String.Empty;

            }
            else
            {
                Session["VIDs"] = combo.WebUser.VIDs;

            }


            List<Food> hrana = new List<Food>();
            hrana.Add(new Food("Jetrica", new GradeSpread(1, 2, 3, 4, 5), 30.99, "https://hmdk.hr/wp-content/uploads/2019/02/15.jpg", 11));
            hrana.Add(new Food("Juha", new GradeSpread(1, 2, 3, 4, 5), 343.2, "https://hmdk.hr/wp-content/uploads/2019/02/15.jpg", 12));
            hrana.Add(new Food("Špageti", new GradeSpread(1, 2, 3, 4, 5), 342, "https://hmdk.hr/wp-content/uploads/2019/02/15.jpg", 13));
            hrana.Add(new Food("Sarma", new GradeSpread(1, 2, 3, 4, 5), 10.15, "https://hmdk.hr/wp-content/uploads/2019/02/15.jpg", 14));
            hrana.Add(new Food("Riba", new GradeSpread(1, 2, 3, 4, 5), 3.2, "https://hmdk.hr/wp-content/uploads/2019/02/15.jpg", 15));
            List<Wine> vina = new List<Wine>();
            vina.Add(new Wine("Graševina", new GradeSpread(1, 2, 3, 4, 5), 3.2, "https://img.etimg.com/thumb/msid-44856181,width-1200,height-900,imgsize-95099,overlay-etpanache/photo.jpg", 21));
            vina.Add(new Wine("Hrnjevac", new GradeSpread(1, 2, 3, 4, 5), 3.2, "https://img.etimg.com/thumb/msid-44856181,width-1200,height-900,imgsize-95099,overlay-etpanache/photo.jpg", 22));
            vina.Add(new Wine("Pinot", new GradeSpread(1, 2, 3, 4, 5), 3.2, "https://img.etimg.com/thumb/msid-44856181,width-1200,height-900,imgsize-95099,overlay-etpanache/photo.jpg", 23));
            vina.Add(new Wine("Plavac", new GradeSpread(1, 2, 3, 4, 5), 3.2, "https://img.etimg.com/thumb/msid-44856181,width-1200,height-900,imgsize-95099,overlay-etpanache/photo.jpg", 24));
            GradeSpread gradeSpread = new GradeSpread(20, 6, 15, 63, 150);
            //GradeSpread gradeSpread = new GradeSpread(0, 0, 0, 0, 0);
            string opis = "Ovaj restoran ima najukusniju hranu, najbolja vina, i predivnu atmosferu";



            //while (opis.Length < WebApiApplication.DESCRIPTION_LENGTH)
            //{
            //    opis = " " + opis;
            //}
            //foreach (var r in WebApiApplication.restaurants)
            //{
            //    while (r.RestaurantDetails.Length < WebApiApplication.DESCRIPTION_LENGTH)
            //    {
            //        r.RestaurantDetails = " " + r.RestaurantDetails;
            //    }
            //}

            RestaurantModel restaurant1 = new RestaurantModel("drugi sadfa", opis, hrana, vina, gradeSpread, "https://www.visit-pag.com/photos/tours/thumbs/restaurant-amare-5e03403b1fa96935512841_huge.jpg",3);
            RestaurantModel restaurant2 = new RestaurantModel("treći", opis, hrana, vina, gradeSpread, "https://www.visit-pag.com/photos/tours/thumbs/restaurant-amare-5e03403b1fa96935512841_huge.jpg",4);
            RestaurantModel restaurant3 = new RestaurantModel("četvrti", opis, hrana, vina, gradeSpread, "https://www.visit-pag.com/photos/tours/thumbs/restaurant-amare-5e03403b1fa96935512841_huge.jpg",5);
            RestaurantModel restaurant4 = new RestaurantModel("peti", opis, hrana, vina, gradeSpread, "https://www.visit-pag.com/photos/tours/thumbs/restaurant-amare-5e03403b1fa96935512841_huge.jpg",6);
            RestaurantModel restaurant5 = new RestaurantModel("šesti",opis, hrana, vina, gradeSpread, "https://www.visit-pag.com/photos/tours/thumbs/restaurant-amare-5e03403b1fa96935512841_huge.jpg",7);
            RestaurantModel restaurant6 = new RestaurantModel("sedmi",opis, hrana, vina, gradeSpread, "https://www.visit-pag.com/photos/tours/thumbs/restaurant-amare-5e03403b1fa96935512841_huge.jpg",8);
            RestaurantModel restaurant7 = new RestaurantModel("osmi",opis, hrana, vina, gradeSpread, "https://www.visit-pag.com/photos/tours/thumbs/restaurant-amare-5e03403b1fa96935512841_huge.jpg",9);
            RestaurantModel restaurant8 = new RestaurantModel("deveti",opis, hrana, vina, gradeSpread, "https://www.visit-pag.com/photos/tours/thumbs/restaurant-amare-5e03403b1fa96935512841_huge.jpg",10);
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
            if (ViewBag.Info == null)
            {
                ViewBag.Info = String.Empty;
            }
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