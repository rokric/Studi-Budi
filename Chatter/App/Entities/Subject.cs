﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public struct Subject
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //test
        public Subject(string title, string description)
        {
            this.Title = title;
            this.Description = description;
        }
    }
}
