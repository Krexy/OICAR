using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DeskApp.Models
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/FineRestAPI.Models.Restaurant")]
    public class GradeSpread
    {
        [DataMember(Order = 1)]
        public int One  { get; set; }
        [DataMember(Order = 2)]
        public int Two { get; set; }
        [DataMember(Order = 3)]
        public int Three { get; set; }
        [DataMember(Order = 4)]
        public int Four { get; set; }
        [DataMember(Order = 5)]
        public int Five { get; set; }

        public GradeSpread(int one,int two,int three,int four, int five)
        {
            One = one;
            Two = two;
            Three = three;
            Four = four;
            Five = five;
        }
        public GradeSpread()
        {

        }
    }
}
