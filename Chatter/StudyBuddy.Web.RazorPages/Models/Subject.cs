﻿using System;
using System.Collections.Generic;

namespace StudyBuddy.Web.RazorPages.Models
{
    public partial class Subject
    {
        public int Subjectid { get; set; }
        public string Title { get; set; }

        public ICollection<Teaching> Teachings { get; set; }
    }
}
