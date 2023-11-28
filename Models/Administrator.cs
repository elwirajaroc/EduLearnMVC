using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduLearnMVC.Models
{
    public class Administrator
    {
        public int AdministratorID { get; set; }
        public int AccountID { get; set; }
        public virtual ICollection<Course> ManagedCourses { get; set; }
    }
}