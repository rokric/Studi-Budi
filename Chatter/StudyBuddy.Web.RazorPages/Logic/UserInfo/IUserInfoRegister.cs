﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public interface IUserInfoRegister
    {
        public void WriteUserInfo(string username, string password, string profession);
    }
}
