using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduLearnMVC.Models
{
    public class Test
    {
        public int TestID { get; set; }
        public DateTime Date_scheduled { get; set; }
        public int Duration { get; set; }
        public virtual ICollection<TestResult> TestResults { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}