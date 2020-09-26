using FineRestAPI.Models.DBLogic;
using FineRestAPI.Models.Restaurant;
using FineRestAPI.Models.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FineRestAPI.Controllers
{
    public class WebAppController : ApiController
    {
        [Route("api/restaurant/web/login")]
        public RestaurantsUserCombo PostLogin([FromBody]Login loginObject)
        {

            return DBLogic.WebUserLogin(loginObject);

        }
        [Route("api/restaurant/web/reg")]
        public void PostInsert([FromBody]WebUser wu)
        {
            if(wu !=null) { 
            DBLogic.WebUserRegister(wu);
            }

        }
        [Route("api/restaurant/web/{restaurantName}/food")]
        public List<Food> GetFood(string restaurantName)
        {

           return DBLogic.ListOfFoodForRestaurant(restaurantName);

        }
        [Route("api/restaurant/web/{restaurantName}/wine")]
        public List<Wine> GetWine(string restaurantName)
        {

            return DBLogic.ListOfWineForRestaurant(restaurantName);

        }
        [Route("api/restaurant/web/{restaurantName}/grade")]
        public GradeSpread GetGrade(string restaurantName)
        {

            return DBLogic.ListOfGradeForRestaurant(restaurantName);

        }
        [Route("api/restaurant/web/grade")]
        public RestaurantsUserCombo Grade([FromBody]RestaurantUserCombo restaurantUserCombo)
        {

            return DBLogic.GradeRestaurant(restaurantUserCombo);

        }
        [Route("api/restaurant/web/vid")]
        [HttpGet]
        public int VID()
        {
            Random rnd = new Random();
            return rnd.Next();

        }
    }
}
