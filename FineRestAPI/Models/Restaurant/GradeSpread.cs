using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FineRestAPI.Models.Restaurant
{
    [DataContract]
    public class GradeSpread
    {
        public int id { get; set; }
        [DataMember(Order=0)]
        public int One { get; set; }
        [DataMember(Order = 1)]
        public int Two { get; set; }
        [DataMember(Order = 2)]
        public int Three { get; set; }
        [DataMember(Order = 3)]
        public int Four { get; set; }
        [DataMember(Order = 4)]
        public int Five { get; set; }
    }
}