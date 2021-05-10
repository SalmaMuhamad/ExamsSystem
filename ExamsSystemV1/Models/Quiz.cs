using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamsSystemV1.Models
{
    public class Quiz : BaseEntity
    {
        public String Name { get; set; }
        public int Degree { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}