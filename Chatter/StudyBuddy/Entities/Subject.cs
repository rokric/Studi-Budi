using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy
{
    public struct Subject
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //test
        public Subject(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
