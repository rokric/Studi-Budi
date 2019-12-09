using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyBuddy.Web.RazorPages.Models
{
    public partial class Teaching
    {
        public int Userid { get; set; }
        public int Subjectid { get; set; }

        [ForeignKey("Userid")]
        public User User { get; set; }

        [ForeignKey("Subjectid")]
        public Subject Subject { get; set; }
    }
}
