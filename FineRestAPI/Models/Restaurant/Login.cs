using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FineRestAPI.Models.Restaurant
{
    [DataContract]
    public class Login
    {
        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [DataMember(Order = 0)]
        public string Username { get; set; }
        [DataMember(Order = 1)]
        public string Password { get; set; }
    }
}