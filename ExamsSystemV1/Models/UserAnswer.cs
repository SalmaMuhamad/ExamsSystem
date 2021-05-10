using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamsSystemV1.Models
{
    public class UserAnswer : BaseEntity
    {

        //public int? User_ID { get; set; }
        public virtual  ApplicationUser ApplicationUser { get; set; }
        //public int? Question_ID { get; set; }
        public virtual Question Question { get; set; }
        //public int? Choice_ID { get; set; }
        public virtual Choice Choice { get; set; }
        public int UserDegree { get; set; }


    }
}