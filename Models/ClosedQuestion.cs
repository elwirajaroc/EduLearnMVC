using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduLearnMVC.Models
{
    public class ClosedQuestion
    {
        public int ClosedQuestionID { get; set; }
        public int QuestionID { get; set; }
        public string Answer { get; set; }
    }
}