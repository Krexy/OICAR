using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApp.Models
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/FineRestAPI.Models.Web")]
    public class WebUser
    {
        [DataMember(Order = 0)]
        public string Username { get; set; }
        [DataMember(Order = 1)]
        public string Pass { get; set; }

        [DataMember(Order = 2)]
        public string Email { get; set; }
        [DataMember(Order = 3)]
        public string VIDs { get; set; }

        public WebUser(string username, string pass, string email, string vids)
        {
            Username = username;
            Pass = pass;
            Email = email;
            VIDs = vids;
        }

        public WebUser()
        {

        }
    }
}