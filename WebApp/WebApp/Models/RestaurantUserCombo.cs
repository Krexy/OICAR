using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class RestaurantUserCombo
    {
        public RestaurantModel RestaurantModel { get; set; }

        public WebUser WebUser { get; set; }
    }
}