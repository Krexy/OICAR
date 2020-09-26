using FineRestAPI.Models.Restaurant;
using FineRestAPI.Models.Web;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FineRestAPI.Models.DBLogic
{
    public class DBLogic
    {
        public static RestaurantOwner GetRestaurantOwner(Login loginObject)
        {
            using (RestaurantContext db = new RestaurantContext())
            {
                if (db.RestaurantOwners.ToList().Count == 0)
                {
                    return new RestaurantOwner();
    
                }
                RestaurantOwner ro = db.RestaurantOwners.Include("Restaurant.Grade").Include("Restaurant.Food.Grade").Include("Restaurant.Wine.Grade").Where(item => item.Username.Equals(loginObject.Username)).FirstOrDefault();
                if (ro.Pass.Equals(loginObject.Password))
                {
                    return ro;
                }
                else
                {
                    return new RestaurantOwner();
                }

            }
        }
        public static void InsertRestaurantOwner(RestaurantOwner ro)
        {

            using (RestaurantContext db = new RestaurantContext())
            {
                if (ro == null)
                {
                    return;
                }
                if (db.RestaurantOwners.ToList().Count == 0)
                {
                    db.RestaurantOwners.Add(ro);
                    db.SaveChanges();
                    return;
                }
                int rmId;
                foreach (var item in db.RestaurantOwners.Include("Restaurant.Grade").Include("Restaurant.Food.Grade").Include("Restaurant.Wine.Grade"))
                {
                    if (item.Username.Equals(ro.Username))
                    {

                        rmId = item.Restaurant.id;
                        db.RestaurantOwners.Remove(item);



                    }


                }
                db.RestaurantOwners.Add(ro);

                db.SaveChanges();

            }

        }



        internal static RestaurantsUserCombo GradeRestaurant(RestaurantUserCombo restaurantUserCombo)
        {
            RestaurantsUserCombo restaurantsUserCombo = new RestaurantsUserCombo();

            using (RestaurantContext dbr = new RestaurantContext())
            {

                foreach (var item in dbr.RestaurantOwners.Include("Restaurant.Grade").Include("Restaurant.Wine.Grade").Include("Restaurant.Food.Grade"))
                {
                    if (item.Restaurant.VID == restaurantUserCombo.RestaurantModel.VID)
                    {
                        item.Restaurant = restaurantUserCombo.RestaurantModel;

                    }
                }

                List<RestaurantModel> rm = new List<RestaurantModel>();
                foreach (var item in dbr.RestaurantOwners.Include("Restaurant.Grade").Include("Restaurant.Wine.Grade").Include("Restaurant.Food.Grade"))
                {
                    rm.Add(item.Restaurant);
                }

                foreach (var item in dbr.WebUsers)
                {
                    if (item.Username.Equals(restaurantUserCombo.WebUser.Username))
                    {
                        item.VIDs = restaurantUserCombo.WebUser.VIDs;

                        restaurantsUserCombo.WebUser = item;

                    }
                }
                restaurantsUserCombo.RestaurantModels = rm;


                dbr.SaveChanges();


                return restaurantsUserCombo;
            }





        }

        public static RestaurantsUserCombo WebUserLogin(Login loginObject)
        {
            RestaurantsUserCombo ruc = new RestaurantsUserCombo();

            using (RestaurantContext db = new RestaurantContext())
            {
                if (db.WebUsers.ToList().Count == 0)
                {
                    return ruc;
                }
                WebUser wu = db.WebUsers.Where(item => item.Username.Equals(loginObject.Username)).FirstOrDefault();
                if(wu == null)
                {
                    return ruc;
                }
                if (wu.Pass.Equals(loginObject.Password))
                {
                    ruc.WebUser = wu;
                    using (RestaurantContext dbr = new RestaurantContext())
                    {
                        List<RestaurantModel> rm = new List<RestaurantModel>();
                        foreach (var item in dbr.RestaurantOwners.Include("Restaurant.Grade").Include("Restaurant.Wine.Grade").Include("Restaurant.Food.Grade"))
                        {
                            rm.Add(item.Restaurant);
                        }
                        ruc.RestaurantModels = rm;
                        return ruc;
                    }

                }
                else
                {
                    return ruc;
                }

            }
        }
        public static void WebUserRegister(WebUser wu)
        {
            using (RestaurantContext db = new RestaurantContext())
            {
                if (db.WebUsers.ToList().Count == 0)
                {
                    db.WebUsers.Add(wu);
                }
                foreach (var item in db.WebUsers)
                {
                    if (item.Username.Equals(wu.Username))
                    {
                        db.WebUsers.Remove(item);
                    }
                }
                db.WebUsers.Add(wu);
                db.SaveChanges();
            }
        }

        public static List<Food> ListOfFoodForRestaurant(string restaurantName)
        {
            using (RestaurantContext db = new RestaurantContext())
            {

                return db.RestaurantOwners.Include("Restaurant").Include("Restaurant.Food.Grade").Where(item => item.Restaurant.RestaurantName.Equals(restaurantName)).FirstOrDefault().Restaurant?.Food;
            }
        }
        public static List<Wine> ListOfWineForRestaurant(string restaurantName)
        {
            using (RestaurantContext db = new RestaurantContext())
            {

                return db.RestaurantOwners.Include("Restaurant").Include("Restaurant.Wine.Grade").Where(item => item.Restaurant.RestaurantName.Equals(restaurantName)).FirstOrDefault().Restaurant?.Wine;
            }
        }
        public static GradeSpread ListOfGradeForRestaurant(string restaurantName)
        {
            using (RestaurantContext db = new RestaurantContext())
            {

                return db.RestaurantOwners.Include("Restaurant.GradeS").Include("Restaurant.Food.Grade").Include("Restaurnt.Wine.Grade").Where(item => item.Restaurant.RestaurantName.Equals(restaurantName)).FirstOrDefault().Restaurant.Grade;
            }
        }
    }
}