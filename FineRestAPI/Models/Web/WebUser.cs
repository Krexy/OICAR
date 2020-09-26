using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FineRestAPI.Models.Web
{
    [DataContract]
    public class WebUser
    {
        public int id { get; set; }
        [DataMember(Order =0)]
        public string Username { get; set; }
        [DataMember(Order = 1)]
        public string Pass { get; set; }
        [DataMember(Order = 2)]
        public string Email { get; set; }
        [DataMember(Order = 3)]
        public string VIDs { get; set; }
    }
}