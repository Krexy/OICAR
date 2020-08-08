using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApp.Models
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/FineRestAPI.Models.Restaurant")]
    public class Login
    {
        [DataMember(Order = 0)]
        public string Username { get; set; }
        [DataMember(Order = 1)]
        public string Password { get; set; }

        public Login(string username, string pass)
        {
            Username = username;
            Password = pass;
        }
        public Login()
        {

        }
    }
}