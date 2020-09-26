using FineRestAPI.Models.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FineRestAPI.Models.Restaurant
{
    [DataContract]
    public class RestaurantUserCombo
    {
        [DataMember(Order = 0)]
        public WebUser WebUser { get; set; }
        [DataMember(Order = 1)]
        public RestaurantModel RestaurantModel { get; set; }
    }
}