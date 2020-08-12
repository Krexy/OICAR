using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DeskApp.Models
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/FineRestAPI.Models.Restaurant")]
    public class RestaurantOwner
    {
        [DataMember(Order = 0)]
        public string Username { get; set; }

        [DataMember(Order = 1)]
        public string Pass { get; set; }

        [DataMember(Order = 2)]
        public RestaurantModel Restaurant { get; set; }

        public RestaurantOwner(string username, string pass, RestaurantModel restaurant)
        {
            Username = username;
            Pass = pass;
            Restaurant = restaurant;
        }
        public RestaurantOwner()
        {

        }
    }
}
