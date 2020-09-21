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
        public List<Food> Food { get; set; }

        [DataMember(Order = 3)]
        public List<Wine> Wine { get; set; }

        [DataMember(Order = 4)]
        public string Image { get; set; }

        [DataMember(Order = 5)]
        public GradeSpread Grade { get; set; }
        [DataMember(Order = 6)]
        public int VID { get; set; }

        public RestaurantModel(string name, string details, List<Food> food, List<Wine> wina, GradeSpread grade, string img, int vid)
        {
            RestaurantName = name;
            RestaurantDetails = details;
            Food = food;
            Wine = wina;
            Image = img;
            Grade = grade;
            VID = vid;
        }

        public RestaurantModel()
        {

        }

    }
}