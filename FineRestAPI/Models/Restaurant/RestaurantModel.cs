using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FineRestAPI.Models.Restaurant
{
    [DataContract]
    public class RestaurantModel
    {
        public RestaurantModel()
        {
        }

        public RestaurantModel(string restaurantName, string restaurantDetails, List<Food> food, List<Wine> wine, GradeSpread grade, string image)
        {
            RestaurantName = restaurantName;
            RestaurantDetails = restaurantDetails;
            Food = food;
            Wine = wine;
            Grade = grade;
            Image = image;
        }

        public int id { get; set; }

        [DataMember(Order = 0)]
        public string RestaurantName { get; set; }
        [DataMember(Order = 1)]
        public string RestaurantDetails { get; set; }
        [DataMember(Order = 2)]
        [Required]
        public List<Food> Food { get; set; }
        [DataMember(Order = 3)]
        [Required]
        public List<Wine> Wine { get; set; }
        [DataMember(Order = 5)]
        [Required]
        public GradeSpread Grade { get; set; }
        [DataMember(Order = 4)]
        public string Image { get; set; }
        [DataMember(Order = 5)]
        public int VID { get; set; }


    }
}