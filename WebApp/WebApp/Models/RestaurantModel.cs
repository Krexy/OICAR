using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Web;

namespace WebApp.Models
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/FineRestAPI.Models.Restaurant")]
    public class RestaurantModel
    {
        [DataMember(Order = 0)]
        public string RestaurantName { get; set; }

        [DataMember(Order = 1)]
        public string RestaurantDetails { get; set; }

        [DataMember(Order = 2)]
        public String Food { get; set; }

        [DataMember(Order = 3)]
        public String Wine { get; set; }

        [DataMember(Order = 4)]
        public double Grade { get; set; }

        [DataMember(Order = 5)]
        public String Image { get; set; }

        public RestaurantModel(string name, string details,string food, string wina, double grade, string img)
        {
            RestaurantName = name;
            RestaurantDetails = details;
            Food = food;
            Wine = wina;
            Grade = grade;
            Image = img;
        }

        public RestaurantModel()
        {

        }

    }
}