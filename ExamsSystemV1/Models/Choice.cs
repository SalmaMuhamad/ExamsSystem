using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamsSystemV1.Models
{
    public class Choice : BaseEntity
    {
        public string Text { get; set; }
        public bool Is_Correct { get; set; }
        public int Degree { get; set; }
        //public int Question_ID { get; set; }
        public virtual Question Questions { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }


    }
}