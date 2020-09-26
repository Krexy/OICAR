using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FineRestAPI.Models.Restaurant
{
    [DataContract]
    public class RestaurantOwner
    {
        public RestaurantOwner()
        {
        }

        public RestaurantOwner(string username, string pass, RestaurantModel restaurant)
        {
            Username = username;
            Pass = pass;
            Restaurant = restaurant;
        }

        public int id { get; set; }
        [DataMember(Order = 0)]
        public string Username { get; set; }
        [DataMember(Order = 1)]
        public string Pass { get; set; }
        [DataMember(Order = 2)]

        [Required]
        public  RestaurantModel Restaurant { get; set; }
    }
}