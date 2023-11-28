using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace EduLearnMVC.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public int Group_number { get; set; }
        public int CourseID { get; set; }
        public virtual ICollection<CourseDescription> CourseDescriptions { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}