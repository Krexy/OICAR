using FineRestAPI.Models.DBLogic;
using FineRestAPI.Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FineRestAPI.Controllers
{
    public class RestaurantController : ApiController
    {
      
        [Route("api/restaurant/desktop/login")]
        public RestaurantOwner PostLogin([FromBody]Login loginObject)
        {

            return DBLogic.GetRestaurantOwner(loginObject);
            
        }
        [Route("api/restaurant/desktop/insert")]
        public void PostInsert([FromBody]RestaurantOwner ro)
        {

             DBLogic.InsertRestaurantOwner(ro);

        }
    }
}
