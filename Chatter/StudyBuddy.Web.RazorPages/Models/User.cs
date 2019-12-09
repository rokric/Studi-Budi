using System;
using System.Collections.Generic;

namespace StudyBuddy.Web.RazorPages.Models
{
    public partial class User
    {
        public int Userid { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public string Profession { get; set; }
        public ICollection<Ban> Bans { get; set; }
        public ICollection<FAQ> FAQs { get; set; }
        public ICollection<Report> Reports { get; set; }
        public ICollection<SubjectRequest> SubjectRequests { get; set; }
        public ICollection<Teaching> Teachings { get; set; }
    }
}
