using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApp.Models
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/FineRestAPI.Models.Restaurant")]
    public class Wine
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }
        [DataMember(Order = 2)]
        public GradeSpread Grade { get; set; }
        [DataMember(Order = 3)]
        public double Price { get; set; }
        [DataMember(Order = 4)]
        public string Image { get; set; }
        public Wine(string name, GradeSpread spread, double price, string image)
        {
            Name = name;
            Grade = spread;
            Price = price;
            Image = image;
        }
        public Wine()
        {

        }

    }
}