using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduLearnMVC.Models
{
    public class CourseDescription
    {
        public int CourseDescriptionID { get; set; }
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
        public int GroupID { get; set; }
        public virtual Group Group { get; set; }
        public string Detailed_description { get; set; }
    }
}