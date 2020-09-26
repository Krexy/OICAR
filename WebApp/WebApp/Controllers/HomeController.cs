using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
            WebApiApplication.filteredRestaurants = WebApiApplication.restaurants.Where(r => r.RestaurantName.ToLower().Contains(filter.ToLower())).ToList();
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
            string currentUser = Session["username"] as String;
            RestaurantModel model = WebApiApplication.restaurants.Where(r => r.RestaurantName == RestaurantName).FirstOrDefault();


            //StringBuilder stringBuilder = new StringBuilder();
            //int postfix = 1;
            //    //umjesto 4 napisi listu hrane iz restorana
            //    for (int i = 0; i < 4; i++)
            //    {
            //        for (int j = 0; j < 5; j++)
            //        {
            //            stringBuilder.Append(Request.Form["cbf" + postfix.ToString()]);
            //            if (!(i == 3 && j == 4))
            //            {
            //                stringBuilder.Append(",");
            //            }
            //            postfix++;
            //        }
            //    }
            SetRestaurantGradeSpread("cbr", model);
            List<GradeSpread> FGradeSpread = GetGradeSpread("cbf", model);
            List<GradeSpread> WGradeSpread = GetGradeSpread("cbw", model);

            int Fcounter = 0;
            if (FGradeSpread != null)
            {

                foreach (var food in FGradeSpread)
                {
                    model.Food[Fcounter].Grade.One += food.One;
                    model.Food[Fcounter].Grade.Two += food.Two;
                    model.Food[Fcounter].Grade.Three += food.Three;
                    model.Food[Fcounter].Grade.Four += food.Four;
                    model.Food[Fcounter].Grade.Five += food.Five;
                    Fcounter++;
                }
            }

            int Wcounter = 0;
            if (WGradeSpread != null)
            {
                foreach (var wine in WGradeSpread)
                {
                    model.Wine[Wcounter].Grade.One += wine.One;
                    model.Wine[Wcounter].Grade.Two += wine.Two;
                    model.Wine[Wcounter].Grade.Three += wine.Three;
                    model.Wine[Wcounter].Grade.Four += wine.Four;
                    model.Wine[Wcounter].Grade.Five += wine.Five;
                    Wcounter++;
                }
            }



            RestaurantUserCombo restaurantUserCombo = new RestaurantUserCombo() { RestaurantModel = model, WebUser = new WebUser() { Username = currentUser } };

            //string xmlPath = ControllerContext.HttpContext.Server.MapPath("~/example.xml");

            WebApiApplication.BackendPostWithReturn<RestaurantUserCombo, RestaurantsUserCombo>(restaurantUserCombo, WebApiApplication.URL_GRADE_UPDATE_PATH);
            //Session["username"] = return_value.WebUser.Username;
            //WebApiApplication.restaurants = return_value.RestaurantModels;
            WebApiApplication.filteredRestaurants = WebApiApplication.restaurants;

            return View("RestaurantDetails", model);
        }

        private void SetRestaurantGradeSpread(string clue, RestaurantModel model)
        {

            String grade = Request.Form[clue];
            //List<string> grades = request.ToString().Split(',').ToList();

            //foreach (var grade in grades)
            //{
            switch (grade)
            {
                case "One":
                    model.Grade.One += 1;
                    break;
                case "Two":
                    model.Grade.Two += 1;
                    break;
                case "Three":
                    model.Grade.Three += 1;
                    break;
                case "Four":
                    model.Grade.Four += 1;
                    break;
                case "Five":
                    model.Grade.Five += 1;
                    break;
                default:
                    break;
            }
            //}
        }

        private List<GradeSpread> GetGradeSpread(string clue, RestaurantModel model)
        {

            List<GradeSpread> finalGradeSpreads = new List<GradeSpread>();

            StringBuilder stringBuilder = new StringBuilder();

            int prefix = 1;
            if (clue == "cbf")
            {
                if (model.Food.Count == 0)
                {
                    return null;
                }
                //umjesto 4 napisi listu hrane iz restorana
                //for (int i = 0; i < 4; i++)
                //{
                //    for (int j = 0; j < 5; j++)
                //    {
                //        stringBuilder.Append(Request.Form[clue + i.ToString() + postfix.ToString()]);
                //        if (!(i == 3 && j == 4))
                //        {
                //            stringBuilder.Append(",");
                //        }
                //        postfix++;
                //    }
                //}
                for (int i = 0; i < model.Food.Count; i++)
                {
                    stringBuilder.Append(Request.Form[clue + prefix.ToString()]);
                    if (!(i == model.Food.Count - 1))
                    {
                        stringBuilder.Append(",");
                    }
                    prefix++;

                }
            }
            else
            {
                //umjesto 4 napisi listu vina iz restorana
                //for (int i = 0; i < 4; i++)
                //{
                //    for (int j = 0; j < 5; j++)
                //    {
                //        stringBuilder.Append(Request.Form[clue + i.ToString() + prefix.ToString()]);
                //        if (!(i == 3 && j == 4))
                //        {
                //            stringBuilder.Append(",");

                //        }
                //        prefix++;
                //    }

                //}
                if (model.Wine.Count == 0)
                {
                    return null;
                }
                for (int i = 0; i < model.Wine.Count; i++)
                {
                    stringBuilder.Append(Request.Form[clue + prefix.ToString()]);
                    if (!(i == model.Wine.Count - 1))
                    {
                        stringBuilder.Append(",");
                    }
                    prefix++;

                }

            }


            //List<string> splitcb = checkedCheckBoxes.Split(',').ToList();
            List<string> grades = stringBuilder.ToString().Split(',').ToList();
            //List<string> fixedcb = new List<string>();

            foreach (var grade in grades)
            {
                GradeSpread gradeSpread = new GradeSpread() { One = 0, Two = 0, Three = 0, Four = 0, Five = 0 };
                switch (grade)
                {
                    case "One":
                        gradeSpread.One = 1;
                        finalGradeSpreads.Add(gradeSpread);
                        break;
                    case "Two":
                        gradeSpread.Two = 1;
                        finalGradeSpreads.Add(gradeSpread);
                        break;
                    case "Three":
                        gradeSpread.Three = 1;
                        finalGradeSpreads.Add(gradeSpread);
                        break;
                    case "Four":
                        gradeSpread.Four = 1;
                        finalGradeSpreads.Add(gradeSpread);
                        break;
                    case "Five":
                        gradeSpread.Five = 1;
                        finalGradeSpreads.Add(gradeSpread);
                        break;
                    default:
                        finalGradeSpreads.Add(gradeSpread);
                        break;
                }

            }

            //bool switcher = true;
            //foreach (var item in splitcb)
            //{
            //    if (item == "on" && switcher)   //true
            //    {
            //        fixedcb.Add(item);
            //        switcher = false;
            //    }
            //    else if (item == "" && !switcher)  //false
            //    {
            //        switcher = true;
            //    }
            //    else
            //    {
            //        fixedcb.Add(item);
            //    }

            //}


            //for (int i = 0; i < fixedcb.Count;)
            //{
            //    GradeSpread gradeSpread = new GradeSpread() { One = 0, Two = 0, Three = 0, Four = 0, Five = 0 };
            //    int innerCounter = 5;
            //    int step = 1;
            //    while (innerCounter > 0)
            //    {
            //        if (step == 5 && fixedcb[i] == "true")
            //        {
            //            gradeSpread.Five = 1;
            //            finalGradeSpreads.Add(gradeSpread);
            //            break;
            //        }
            //        if (fixedcb[i] == "false")
            //        {
            //            if (step % 5 == 0)
            //            {
            //                gradeSpread.Four = 1;
            //            }
            //            else if (step % 4 == 0)
            //            {
            //                gradeSpread.Three = 1;
            //            }
            //            else if (step % 3 == 0)
            //            {
            //                gradeSpread.Two = 1;
            //            }
            //            else if (step % 2 == 0)
            //            {
            //                gradeSpread.One = 1;
            //            }
            //            //else if (step % 1 == 0)
            //            //{
            //            //    gradeSpread.One = 1;
            //            //}
            //            finalGradeSpreads.Add(gradeSpread);
            //            break;
            //        }
            //        innerCounter--;
            //        i++;
            //        step++;
            //    }
            //    i += 6 - step;
            //}

            return finalGradeSpreads;
        }
    }
}
