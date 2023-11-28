using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduLearnMVC.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public int AccountID { get; set; }
        public string Content { get; set; }
        public DateTime Date_published { get; set; }
        public virtual Account SenderAccount { get; set; }
    }
}