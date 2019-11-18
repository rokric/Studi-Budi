﻿using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic.Profile
{
    public interface IProfile
    {
        bool IsPasswordMaches(string password, int ID);
        public string GetPasswordByID(int ID);

        Task PasswordChange( string New, int Id);
         Task NameChange(string New, int Id);
        public bool IsPasswordGood(string? password);

    }
}