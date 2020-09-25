using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApp.Models
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/FineRestAPI.Models.Restaurant")]
    public class RestaurantsUserCombo
    {
        [DataMember(Order = 0)]
        public WebUser WebUser { get; set; }
        [DataMember(Order = 1)]
        public List<RestaurantModel> RestaurantModels { get; set; }
   
        public RestaurantsUserCombo(WebUser webUser, List<RestaurantModel> restaurantModels)
        {
            WebUser = webUser;
            RestaurantModels = restaurantModels;
        }

        public RestaurantsUserCombo()
        {

        }

    }
}