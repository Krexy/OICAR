using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FineRestAPI.Models.Restaurant
{
    [DataContract]
    public class Food
    {
        public int Id { get; set; }
        [DataMember(Order=0)]
        public string Name { get; set; }
        [DataMember(Order = 1)]
        [Required]
        public GradeSpread Grade { get; set; }
        [DataMember(Order = 2)]
        public double Price { get; set; }
        [DataMember(Order = 3)]
        public string Image { get; set; }
        [DataMember(Order = 4)]
        public int VID { get; set; }
    }
}