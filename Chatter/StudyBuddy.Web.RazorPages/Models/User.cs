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
    }
}
