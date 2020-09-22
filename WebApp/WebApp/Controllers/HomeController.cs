using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.UI.WebControls;
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

        public ActionResult UpdateGrade(string RestaurantName)
        {


            List<GradeSpread> FGradeSpread = GetGradeSpread("cbf");
            List<GradeSpread> WGradeSpread = GetGradeSpread("cbw");




            string currentUser = Session["username"] as String;
            RestaurantModel model = WebApiApplication.restaurants.Where(r => r.RestaurantName == RestaurantName).FirstOrDefault();

            RestaurantUserCombo restaurantUserCombo = new RestaurantUserCombo() { RestaurantModel = model, WebUser = currentUser };
            string path = ControllerContext.HttpContext.Server.MapPath("~/example.xml");

            WebApiApplication.BackendPostWithReturnTest<RestaurantUserCombo, List<RestaurantModel>>(restaurantUserCombo, path);

            return View("RestaurantDetails", model);
        }

        private List<GradeSpread> GetGradeSpread(string clue)
        {
            List<GradeSpread> finalGradeSpreads = new List<GradeSpread>();
            string checkedCheckBoxes = Request.Form[clue];
            //string checkedCheckBoxes = Request.Form[clue + "0"];
            //string checkedCheckBoxes1 = Request.Form[clue+"1"];
            //string checkedCheckBoxes2 = Request.Form[clue + "2"];
            //string checkedCheckBoxes3 = Request.Form[clue + "3"];
            //string checkedCheckBoxes4 = Request.Form[clue + "4"];
            //string[] splitcb = checkedCheckBoxes.Split(',');
            List<string> splitcb = checkedCheckBoxes.Split(',').ToList();
            List<string> fixedcb = new List<string>();

            bool switcher = true;
            foreach (var item in splitcb)
            {
                if (item == "true" && switcher)
                {
                    //splitcb.Remove(item);
                    fixedcb.Add(item);
                    switcher = false;
                }
                else if (item == "false" && !switcher) {
                    switcher = true;
                }
                else
                {
                    fixedcb.Add(item);
                }

            }


            //splitcb = splitcb.Where(x => ).ToList();
            for (int i = 0; i < fixedcb.Count;)
            {
                GradeSpread gradeSpread = new GradeSpread() { One = 0, Two = 0, Three = 0, Four = 0, Five = 0 };
                int innerCounter = 5;
                int step = 1;
                while (innerCounter > 0)
                {
                    if (step == 5 && fixedcb[i] == "true")
                    {
                        gradeSpread.Five = 1;
                        finalGradeSpreads.Add(gradeSpread);
                        break;
                    }
                    if (fixedcb[i] == "false")
                    {
                        if (step % 5 == 0)
                        {
                            gradeSpread.Four = 1;
                        }
                        else if (step % 4 == 0)
                        {
                            gradeSpread.Three = 1;
                        }
                        else if (step % 3 == 0)
                        {
                            gradeSpread.Two = 1;
                        }
                        else if (step % 2 == 0)
                        {
                            gradeSpread.One = 1;
                        }
                        //else if (step % 1 == 0)
                        //{
                        //    gradeSpread.One = 1;
                        //}
                        finalGradeSpreads.Add(gradeSpread);
                        break;
                    }
                    innerCounter--;
                    i++;
                    step++;
                }
                i+=6-step;
            }

            return finalGradeSpreads;
        }
    }
}
