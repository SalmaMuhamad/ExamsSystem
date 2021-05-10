using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamsSystemV1.Models
{
    public class Question : BaseEntity
    {
        public string Title { get; set; }

        //public int? Quiz_ID { get; set; }
        public virtual Quiz Quiz { get; set; }

        //public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Choice> Choices { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }

    }
}