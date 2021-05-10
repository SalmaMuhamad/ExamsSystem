using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamsSystemV1.Models
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}