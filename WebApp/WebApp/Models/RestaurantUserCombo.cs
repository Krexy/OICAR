using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApp.Models
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/FineRestAPI.Models.Restaurant")]
    public class RestaurantUserCombo
    {
        [DataMember(Order = 0)]
        public WebUser WebUser { get; set; }
        [DataMember(Order = 1)]
        public RestaurantModel RestaurantModel { get; set; }

        public RestaurantUserCombo(WebUser webUser, RestaurantModel restaurantModel)
        {
            WebUser = webUser;
            RestaurantModel = restaurantModel;
        }

        public RestaurantUserCombo()
        {

        }
    }
}